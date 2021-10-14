using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Common.Model.Entities
{
    
    public abstract class BaseEntity : INotifyPropertyChanged, IEntity
    {

        public BaseEntity(bool disableDelete = false)
        {
            Guid = Guid.NewGuid();
            Enabled = true;
            //DisableDelete = disableDelete;
        }

        [Key]
        public virtual long Id { get; set; }

        [NotMapped]
        public virtual Guid Guid { get; set; }

        [Timestamp]
        public virtual byte[] RowVersion { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual bool IsNew
        {
            get
            {
                return Id <= 0;
            }
        }
      
        public override bool Equals(object obj)
        {
            var other = obj as AuditEntity;
            if (other == null)
                return false;
            if (other.GetType() != this.GetType())
                return false;
            return this.Guid.Equals(other.Guid);
        }

        public virtual string Display
        {
            get { return ToString(); }
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string GetValueByProperty(string fieldData, string formatString)
        {
            throw new NotImplementedException();
        }
    }
}
