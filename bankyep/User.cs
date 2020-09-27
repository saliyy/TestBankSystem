using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankyep
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string Name { get; set; }

        public int Face { get; private set; }

        public int creditHistory { get; set; }

        public decimal Cash { get; set; }

        public string Login {  get; private set; }
        public string Password {  get;  private set; }

        public User(string Name,  int Face, int ch, decimal cash, string login, string Password)
        {
            this.Name = Name;
            this.Face = Face;
            this.creditHistory = ch;
            this.Cash = cash;
            this.Login = login;
            this.Password = Password;
        }

        public override string ToString()
        {
            return $"Имя: {Name} | Лицо: {Face} | Кр.История | {creditHistory}";
        }

        public User() : this("", 0, 0, 100, "", "")
        {
               
        }
       

    }
}
