using UnityEngine.SceneManagement;

public class SceneRestarter 
{
   public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
