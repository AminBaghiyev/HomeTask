namespace Group_Student_Class.Models;

internal class DB
{
    public Group[] groups = [];

    public void AddGroup(Group group)
    {
        Array.Resize(ref groups, groups.Length + 1);
        groups[^1] = group;
    }

    public Group? GetGroupByName(string groupName)
    {
        foreach (Group grp in groups)
            if (grp.Name == groupName) return grp;
        return null;
    }

    public string[] GroupNamesToArray()
    {
        string[] groupNames = new string[groups.Length];
        for (int i = 0; i < groups.Length; i++)
        {
            groupNames[i] = groups[i].Name;
        }

        return groupNames;
    }
}
