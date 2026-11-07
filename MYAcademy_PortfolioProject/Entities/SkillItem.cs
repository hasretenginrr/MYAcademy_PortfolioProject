namespace MYAcademy_PortfolioProject.Entities
{
    public class SkillItem
    {
        public int SkillItemId { get; set; }
        public string SkillItemTitle { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}

//Skill --> YapayZeka
//SkillItem --> ChatGPT, Dall-E, MidJourney, Google Bard, Microsoft Copilot, Jasper, Replika, Synthesia, Lumen5, RunwayML
