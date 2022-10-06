using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.Core.Entities
{
    public class Book
    {
        public enum GENRE
        {
            ACTION, ROMANCE, SELF_DEVELOPMENT, SCIENCE
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string GenreText
        {
            get { return Genre.ToString(); }
            set { Genre = (GENRE)System.Enum.Parse(typeof(GENRE), value.ToUpper()); }
        }
        public GENRE Genre { get; set; }
        public double Price { get; set; }
        public int SellCount { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double NSPF { get; private set; }
    }
}
