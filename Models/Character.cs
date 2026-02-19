namespace Console_RPG
{
    public class Character
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public string[] Equipment { get; set; }


        public Character() 
        {
            Name = "";
            Profession = "";
            Equipment = Array.Empty<string>();
        }

        public Character(string name, string profession, int level, int hp, string[] equipment)
        {
            Name = name;
            Profession = profession;
            Level = level;
            HP = hp;
            Equipment = equipment ?? Array.Empty<string>();
        }

        public override string ToString()
        {
            return $"Name: {Name} - Profession: {Profession} - Level: {Level} - HP: {HP} - Equipment: [{string.Join(", ", Equipment)}]";
        }
    }
}
