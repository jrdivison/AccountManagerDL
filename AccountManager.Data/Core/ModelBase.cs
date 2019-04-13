namespace AccountManager.Data.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ModelBase<T>
    {
        public T Id { get; set; } 
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public bool IsNewModel()
        {
            return Id.Equals(default(T));
        }
  
    }
}
