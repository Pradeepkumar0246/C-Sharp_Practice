namespace day6_c_
{
    class LakeViewClub
    {
        static Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>()
    {
        {"Gold", new List<string> {"Tom", "Harry"}},
        {"Silver", new List<string> {"Sam", "Peter"}},
        {"Platinum", new List<string>()}  // Empty initially
    };
        static void AddNewMember(string groupName, string memberName)
        {
            if (groups.ContainsKey(groupName))
            {
                groups[groupName].Add(memberName);

                Console.WriteLine("\nMembers in " + groupName + " group:");
                foreach (var member in groups[groupName])
                {
                    Console.WriteLine(member);
                }
            }
            else
            {
                Console.WriteLine("Invalid group name!");
            }
        }
        internal class q4_addnewmember
        {
            public q4_addnewmember()
            {
                Console.WriteLine("Group Name (Gold/Silver/Platinum):");
                string group = Console.ReadLine();
                Console.WriteLine("Member Name:");
                string name = Console.ReadLine();
                AddNewMember(group, name);
            }
        }
    }
}
