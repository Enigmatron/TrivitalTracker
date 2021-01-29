using System;
using System.ComponentModel.DataAnnotations;

namespace TrivitalTracker.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
