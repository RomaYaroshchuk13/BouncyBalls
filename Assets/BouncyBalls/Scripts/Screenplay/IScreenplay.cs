using Assets.BouncyBalls.Scripts.Balls;
using Assets.BouncyBalls.Scripts.Screenplay;
using Assets.BouncyBalls.Scripts.Sectors;

public interface IScreenplay
{
    void Init(BallsCreator ballsCreator, SectorsCreator sectorsCreator, ScreenplayData screenplayData);
    void Play();
}
