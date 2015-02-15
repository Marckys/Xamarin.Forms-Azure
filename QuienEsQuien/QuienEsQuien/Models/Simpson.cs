
using System.Collections.Generic;

namespace QuienEsQuien.Models
{
    public class Simpson
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsWoman { get; set; }
        public bool IsChild { get; set; }
        public bool IsMostache { get; set; }
        public bool IsBeard { get; set; }
        public bool IsMore40 { get; set; }
        public bool IsBlueHair { get; set; }
    }

    public class InitDb
    {
        public static List<Simpson> GetSimpson()
        {
            return new List<Simpson>
            {
                new Simpson{ Id = "1", Name = "Agnes Skinner", IsWoman = true, IsBeard = false, IsBlueHair = true, IsChild = false, IsMore40 = true, IsMostache = false},
                new Simpson{ Id = "2", Name = "Sr Burns", IsWoman = false, IsBeard = false, IsBlueHair = false, IsChild = false, IsMore40 = true, IsMostache = false},
                new Simpson{ Id = "3", Name = "Barney", IsWoman = false, IsBeard = false, IsBlueHair = false, IsChild = false, IsMore40 = true, IsMostache = false},
                new Simpson{ Id = "4", Name = "Bart", IsWoman = false, IsBeard = true, IsBlueHair = false, IsChild = true, IsMore40 = false, IsMostache = false},
                new Simpson{ Id = "5", Name = "willy", IsWoman = false, IsBeard = false, IsBlueHair = false, IsChild = false, IsMore40 = true, IsMostache = false},
                new Simpson{ Id = "6", Name = "Duffman", IsWoman = true, IsBeard = false, IsBlueHair = true, IsChild = false, IsMore40 = true, IsMostache = false},
                new Simpson{ Id = "7", Name = "Agnes Skinner ", IsWoman = true, IsBeard = false, IsBlueHair = true, IsChild = false, IsMore40 = true, IsMostache = false},
               
                new Simpson{ Id = "8", Name = "Homer", IsWoman = false, IsBeard = false, IsBlueHair = false, IsChild = false, IsMore40 = true, IsMostache = false},
                new Simpson{ Id = "9", Name = "Lenny", IsWoman = false, IsBeard = false, IsBlueHair = false, IsChild = false, IsMore40 = true, IsMostache = false},
                new Simpson{ Id = "10", Name = "Lisa", IsWoman = true, IsBeard = false, IsBlueHair = false, IsChild = true, IsMore40 = false, IsMostache = false},
                new Simpson{ Id = "11", Name = "Maggie", IsWoman = true, IsBeard = false, IsBlueHair = false, IsChild = true, IsMore40 = false, IsMostache = false},
                new Simpson{ Id = "12", Name = "Marge", IsWoman = true, IsBeard = false, IsBlueHair = true, IsChild = false, IsMore40 = true, IsMostache = false},
                new Simpson{ Id = "13", Name = "Milhouse", IsWoman = false, IsBeard = false, IsBlueHair = true, IsChild = true, IsMore40 = false, IsMostache = false},
                new Simpson{ Id = "14", Name = "Flanders", IsWoman = false, IsBeard = false, IsBlueHair = false, IsChild = false, IsMore40 = true, IsMostache = true},
                new Simpson{ Id = "15", Name = "Otto Mann", IsWoman = false, IsBeard = false, IsBlueHair = false, IsChild = false, IsMore40 = false, IsMostache = false},
            };
        }

        public static List<Question> GetQuestions()
        {
            return new List<Question>
            {
                new Question{ Id = "1", Text = "Es Mujer ?"},
                new Question{ Id = "2", Text = "Es Niño/niña ?"},
                new Question{ Id = "3", Text = "Tiene bigote ?"},
                new Question{ Id = "4", Text = "Es mayor de 40 años?"},
                new Question{ Id = "5", Text = "Tiene el pelo azul?"},
                new Question{ Id = "6", Text = "Tiene barba ?"},
            };
        } 
    }

}
