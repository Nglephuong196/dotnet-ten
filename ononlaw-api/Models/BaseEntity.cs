using System.ComponentModel.DataAnnotations;

namespace ononlaw_api.Models
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Unique identifier for the entity
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Date and time when the entity was created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Date and time when the entity was last modified
        /// </summary>
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// Date and time when the entity was deleted (soft delete)
        /// </summary>
        public DateTime? DateDeleted { get; set; }
    }
}
