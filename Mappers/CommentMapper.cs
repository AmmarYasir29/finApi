using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using FinApi.Dtos.SendDto;

namespace FinApi.Mappers;

    public static class CommentMapper
    {
        public static CommentDtoSend ToCommentDto (this Comment commentModel) {
            return new CommentDtoSend {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId
            };
        }
    }