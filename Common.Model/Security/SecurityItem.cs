
using Common.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model.Security
{
    public class SecurityItem : AuditEntity
    {
        /// <summary>Initializes a new instance of the <see cref="SecurityItem"/> class.</summary>
        public SecurityItem() { }

        /// <summary>Initializes a new instance of the <see cref="SecurityItem"/> class.</summary>
        /// <param name="name">The name of Security Item</param>
        public SecurityItem(string name)
        {
            Name = name;
        }

        /// <summary>Gets or sets the group identifier.</summary>
        /// <value>The group identifier.</value>
        public long GroupId { get; set; }
        /// <summary>Gets or sets the security group.</summary>
        /// <value>The group.</value>
        public virtual SecurityGroup Group { get; set; }

        /// <summary>Gets or sets the name of security Item</summary>
        /// <value>The name.</value>
        [Column(TypeName = "VARCHAR"), StringLength(512)]
        public string Name { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        [Column(TypeName = "VARCHAR"), StringLength(1024)]
        public string Description { get; set; }

        /// <summary>Gets or sets the type security item</summary>
        /// <value>The type.</value>
        [Column(TypeName = "VARCHAR"), StringLength(1024)]
        public string Type { get; set; }

        /// <summary>Gets the name of the group item.</summary>
        /// <value>The name of the group item.</value>
        public string GroupItemName { get { return $"{Group?.Name}.{Name}"; } }

        /// <summary>Gets or sets a value indicating whether this instance is selected.</summary>
        /// <value>
        ///   <c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
        [NotMapped]
        public bool IsSelected { get; set; }
    }
}
