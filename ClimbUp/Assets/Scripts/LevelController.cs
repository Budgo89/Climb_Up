namespace Assets.Scripts
{
    public class LevelController
    {
        public int Level { get; set; } = 1;

        public void NextLevel()
        {
            Level++;
        }
    }
}
