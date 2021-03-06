﻿using System;
using System.Collections.Generic;
using System.Linq;
using BlogBounty.Data;
using BlogBounty.Models.TopicViewModels;

namespace BlogBounty.Extensions
{
    public static class EntityExtensions
    {
        public static TopicViewModel ToViewModel(this TopicEntity t)
        {
            return new TopicViewModel
            {
                Description = t.Description,
                Id = t.Id,
                NumberOfSubscriptions = t.Subscriptions.Count,
                NumberOfUpvotes = t.Upvotes.Count,
                Title = t.Title,
                Tags = t.Tags.Select(tt => tt.Tag.Label).ToArray(),
                Creator = t.User.UserName,
                CreatedAt = t.CreatedAt
            };
        }

        public static CommentViewModel ToViewModel(this CommentEntity c)
        {
            return new CommentViewModel
            {
                Id = c.Id,
                Body = c.Body,
                UserName = c.User.UserName,
                TopicId = c.TopicId,
                ParentId = c.ParentId,
                CreatedAt = c.CreatedAt
            };
        }

        public static IEnumerable<CommentViewModel> ToViewModel(this IEnumerable<CommentEntity> comments)
        {
            if (comments == null)
            {
                throw new ArgumentNullException(nameof(comments));
            }

            if (!comments.Any())
            {
                return Enumerable.Empty<CommentViewModel>();
            }

            var commentEntitiys = comments.ToArray();

            var roots = commentEntitiys
                .Where(c => !c.ParentId.HasValue)
                .Select(c => c.ToViewModel())
                .ToArray();

            var children = new Stack<CommentViewModel>(
                commentEntitiys
                    .Where(c => c.ParentId.HasValue)
                    .Select(c => c.ToViewModel()));

            var map = roots
                .Concat(children)
                .ToDictionary(c => c.Id);

            if (!roots.Any())
            {
                throw new ArgumentException("No root comments were found.");
            }

            while (children.Any())
            {
                var next = children.Pop();

                if (map.ContainsKey(next.ParentId.Value))
                {
                    map[next.ParentId.Value].Replies.Add(next);
                }
                else
                {
                    throw new ArgumentException("Parent id not found.");
                }
            }

            return roots;
        }
    }
}