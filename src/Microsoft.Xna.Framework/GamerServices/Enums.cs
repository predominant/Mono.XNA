namespace Microsoft.Xna.Framework.GamerServices
{
    using System;
    using Microsoft.Xna.Framework.GamerServices;

    public enum ControllerSensitivity
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }

    public enum GameDifficulty
    {
        Easy,
        Normal,
        Hard
    }

    public enum GamerPresenceMode
    {
        None,
        SinglePlayer,
        Multiplayer,
        LocalCoOp,
        LocalVersus,
        OnlineCoOp,
        OnlineVersus,
        VersusComputer,
        Stage,
        Level,
        CoOpStage,
        CoOpLevel,
        ArcadeMode,
        CampaignMode,
        ChallengeMode,
        ExplorationMode,
        PracticeMode,
        PuzzleMode,
        ScenarioMode,
        StoryMode,
        SurvivalMode,
        TutorialMode,
        DifficultyEasy,
        DifficultyMedium,
        DifficultyHard,
        DifficultyExtreme,
        Score,
        VersusScore,
        Winning,
        Losing,
        ScoreIsTied,
        Outnumbered,
        OnARoll,
        InCombat,
        BattlingBoss,
        TimeAttack,
        TryingForRecord,
        FreePlay,
        WastingTime,
        StuckOnAHardBit,
        NearlyFinished,
        LookingForGames,
        WaitingForPlayers,
        WaitingInLobby,
        SettingUpMatch,
        PlayingWithFriends,
        AtMenu,
        StartingGame,
        Paused,
        GameOver,
        WonTheGame,
        ConfiguringSettings,
        CustomizingPlayer,
        EditingLevel,
        InGameStore,
        WatchingCutscene,
        WatchingCredits,
        PlayingMinigame,
        FoundSecret,
        CornflowerBlue
    }

    public enum GamerPrivilegeSetting
    {
        Blocked,
        FriendsOnly,
        Everyone
    }
    public enum GamerZone
    {
        Unknown,
        Recreation,
        Pro,
        Family,
        Underground
    }

    public enum RacingCameraAngle
    {
        Back,
        Front,
        Inside
    }
    public enum MessageBoxIcon
    {
        None,
        Error,
        Warning,
        Alert
    }

    public enum NotificationPosition
    {
        TopLeft,
        TopCenter,
        TopRight,
        CenterLeft,
        Center,
        CenterRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

}
