﻿// Type: FanartHandler.FanartRandom
// Assembly: FanartHandler, Version=4.0.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 073E8D78-B6AE-4F86-BDE9-3E09A337833B

extern alias FHNLog;

using MediaPortal.GUI.Library;

using FHNLog.NLog;

using System;
using System.Collections;
using System.Globalization;
using System.Threading.Tasks;
using System.Threading;

namespace FanartHandler
{
  internal class FanartRandom
  {
    // Private
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    private bool DoShowImageOneRandom = true;
    private Hashtable propertiesRandom;

    private ArrayList ListAnyGamesUser;
    private ArrayList ListAnyMoviesScraper;
    private ArrayList ListAnyMoviesUser;
    private ArrayList ListAnyMovingPictures;
    private ArrayList ListAnyMusicScraper;
    private ArrayList ListAnyMusicUser;
    private ArrayList ListAnyPicturesUser;
    private ArrayList ListAnyPluginsUser;
    private ArrayList ListAnyScorecenterUser;
    private ArrayList ListAnyTVSeries;
    private ArrayList ListAnyTVUser;
    private ArrayList ListAnyMyFilms;
    private ArrayList ListAnyShowTimes;
    private ArrayList ListAnySpotLights;

    private ArrayList ListLatestsMusic;
    private ArrayList ListLatestsMvCentral;
    private ArrayList ListLatestsMovies;
    private ArrayList ListLatestsMovingPictures;
    private ArrayList ListLatestsTVSeries;
    private ArrayList ListLatestsMyFilms;

    private int PrevSelectedGamesUser;
    private int PrevSelectedMoviesScraper;
    private int PrevSelectedMoviesUser;
    private int PrevSelectedMovingPictures;
    private int PrevSelectedMusicScraper;
    private int PrevSelectedMusicUser;
    private int PrevSelectedPicturesUser;
    private int PrevSelectedPluginsUser;
    private int PrevSelectedScorecenterUser;
    private int PrevSelectedTVSeries;
    private int PrevSelectedTVUser;
    private int PrevSelectedMyFilms;
    private int PrevSelectedShowTimes;
    private int PrevSelectedSpotLights;

    private int PrevSelectedLatestsMusic;         
    private int PrevSelectedLatestsMvCentral;     
    private int PrevSelectedLatestsMovies;        
    private int PrevSelectedLatestsMovingPictures;
    private int PrevSelectedLatestsTVSeries;      
    private int PrevSelectedLatestsMyFilms;      

    private string currAnyGamesUser;
    private string currAnyMoviesScraper;
    private string currAnyMoviesUser;
    private string currAnyMovingPictures;
    private string currAnyMusicScraper;
    private string currAnyMusicUser;
    private string currAnyPicturesUser;
    private string currAnyPluginsUser;
    private string currAnyScorecenterUser;
    private string currAnyTVSeries;
    private string currAnyTVUser;
    private string currAnyMyFilms;
    private string currAnyShowTimes;
    private string currAnySpotLights;

    private string currLatestsMusic;         
    private string currLatestsMvCentral;     
    private string currLatestsMovies;        
    private string currLatestsMovingPictures;
    private string currLatestsTVSeries;      
    private string currLatestsMyFilms;      

    private int SyncPoinRandomUpdate;
    private int SyncPoinRandomLatestsUpdate;

    /// <summary>
    /// Fanart Control Visible
    /// -1 Unknown, 0 Hiden, 1 Visible
    /// </summary>
    private int ControlVisible;
    /// <summary>
    /// Fanart Image Control Visible
    /// -1 Unknown, 0 Hiden, 1 Visible
    /// </summary>
    private int ControlImageVisible;

    // Public
    public int RefreshTickCount { get; set; }

    public bool FanartAvailable { get; set; }
    public bool IsRandom { get; set; }

    public Hashtable WindowsUsingFanartRandom { get; set; }
    public Hashtable WindowsUsingFanartLatestsRandom { get; set; }

    // 
    static FanartRandom()
    {
    }

    public FanartRandom()
    {
      FanartAvailable = false;

      PrevSelectedGamesUser = -1;
      PrevSelectedMoviesScraper = -1;
      PrevSelectedMoviesUser = -1;
      PrevSelectedMovingPictures = -1;
      PrevSelectedMusicScraper = -1;
      PrevSelectedMusicUser = -1;
      PrevSelectedPicturesUser = -1;
      PrevSelectedPluginsUser = -1;
      PrevSelectedScorecenterUser = -1;
      PrevSelectedTVSeries = -1;
      PrevSelectedTVUser = -1;
      PrevSelectedMyFilms = -1;
      PrevSelectedShowTimes = -1;
      PrevSelectedSpotLights = -1;

      PrevSelectedLatestsMusic = -1;
      PrevSelectedLatestsMvCentral = -1;
      PrevSelectedLatestsMovies = -1;
      PrevSelectedLatestsMovingPictures = -1;
      PrevSelectedLatestsTVSeries = -1;
      PrevSelectedLatestsMyFilms = -1;

      currAnyGamesUser = string.Empty;
      currAnyMoviesScraper = string.Empty;
      currAnyMoviesUser = string.Empty;
      currAnyMovingPictures = string.Empty;
      currAnyMusicScraper = string.Empty;
      currAnyMusicUser = string.Empty;
      currAnyPicturesUser = string.Empty;
      currAnyPluginsUser = string.Empty;
      currAnyScorecenterUser = string.Empty;
      currAnyTVSeries = string.Empty;
      currAnyTVUser = string.Empty;
      currAnyMyFilms = string.Empty;
      currAnyShowTimes = string.Empty;
      currAnySpotLights = string.Empty;

      currLatestsMusic = string.Empty;
      currLatestsMvCentral = string.Empty;
      currLatestsMovies = string.Empty;
      currLatestsMovingPictures = string.Empty;
      currLatestsTVSeries = string.Empty;
      currLatestsMyFilms = string.Empty;

      DoShowImageOneRandom = true;

      RefreshTickCount = 0;

      propertiesRandom = new Hashtable();

      ListAnyGamesUser = new ArrayList();
      ListAnyMoviesUser = new ArrayList();
      ListAnyMoviesScraper = new ArrayList();
      ListAnyMovingPictures = new ArrayList();
      ListAnyMusicUser = new ArrayList();
      ListAnyMusicScraper = new ArrayList();
      ListAnyPicturesUser = new ArrayList();
      ListAnyScorecenterUser = new ArrayList();
      ListAnyTVSeries = new ArrayList();
      ListAnyTVUser = new ArrayList();
      ListAnyPluginsUser = new ArrayList();
      ListAnyShowTimes = new ArrayList();
      ListAnyMyFilms = new ArrayList();
      ListAnySpotLights = new ArrayList();

      ListLatestsMusic = new ArrayList();
      ListLatestsMvCentral = new ArrayList();
      ListLatestsMovies = new ArrayList();
      ListLatestsMovingPictures = new ArrayList();
      ListLatestsTVSeries = new ArrayList();
      ListLatestsMyFilms = new ArrayList();

      IsRandom = false;

      WindowsUsingFanartRandom = new Hashtable();
      WindowsUsingFanartLatestsRandom = new Hashtable();

      SyncPoinRandomUpdate = 0;
      SyncPoinRandomLatestsUpdate = 0;

      ClearCurrProperties();
    }

    public void ClearCurrProperties()
    {
      ControlVisible = -1;
      ControlImageVisible = -1;
    }

    public bool CheckValidWindowIDForFanart()
    {
      return (Utils.ContainsID(WindowsUsingFanartRandom) || Utils.ContainsID(WindowsUsingFanartLatestsRandom));
    }

    #region Refresh Random Image Properties
    public void RefreshRandomMoviesImageProperties(RefreshWorker rw)
    {
      FillPropertyRandom(Utils.Category.Movie, Utils.SubCategory.MovieManual, ref currAnyMoviesUser, ref PrevSelectedMoviesUser, "movie.userdef", ref ListAnyMoviesUser);
      FillPropertyRandom(Utils.Category.Movie, Utils.SubCategory.MovieScraped, ref currAnyMoviesScraper, ref PrevSelectedMoviesScraper, "movie.scraper", ref ListAnyMoviesScraper);
      FillPropertyRandom(Utils.Category.MovingPicture, Utils.SubCategory.MovingPictureManual, ref currAnyMovingPictures, ref PrevSelectedMovingPictures, "movingpicture", ref ListAnyMovingPictures);
      FillPropertyRandom(Utils.Category.MyFilms, Utils.SubCategory.MyFilmsManual, ref currAnyMyFilms, ref PrevSelectedMyFilms, "myfilms.userdef", ref ListAnyMyFilms);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(10, "Movies Updated Properties");
    }

    public void RefreshRandomMusicImageProperties(RefreshWorker rw)
    {
      FillPropertyRandom(Utils.Category.MusicFanart, Utils.SubCategory.MusicFanartManual, ref currAnyMusicUser, ref PrevSelectedMusicUser, "music.userdef", ref ListAnyMusicUser);
      FillPropertyRandom(Utils.Category.MusicFanart, Utils.SubCategory.MusicFanartScraped, ref currAnyMusicScraper, ref PrevSelectedMusicScraper, "music.scraper", ref ListAnyMusicScraper);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(10, "Music Updated Properties");
    }

    public void RefreshRandomTVImageProperties(RefreshWorker rw)
    {
      FillPropertyRandom(Utils.Category.TV, Utils.SubCategory.TVManual, ref currAnyTVUser, ref PrevSelectedTVUser, "tv.userdef", ref ListAnyTVUser);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(10, "TV Updated Properties");
    }

    public void RefreshRandomTVSeriesImageProperties(RefreshWorker rw)
    {
      FillPropertyRandom(Utils.Category.TVSeries, Utils.SubCategory.TVSeriesScraped, ref currAnyTVSeries, ref PrevSelectedTVSeries, "tvseries", ref ListAnyTVSeries);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(10, "TVSeries Updated Properties");
    }

    public void RefreshRandomPicturesImageProperties(RefreshWorker rw)
    {
      FillPropertyRandom(Utils.Category.Picture, Utils.SubCategory.PictureManual, ref currAnyPicturesUser, ref PrevSelectedPicturesUser, "picture.userdef", ref ListAnyPicturesUser);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(10, "Pictures Updated Properties");
    }

    public void RefreshRandomGamesImageProperties(RefreshWorker rw)
    {
      FillPropertyRandom(Utils.Category.Game, Utils.SubCategory.GameManual, ref currAnyGamesUser, ref PrevSelectedGamesUser, "games.userdef", ref ListAnyGamesUser);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(10, "Games Updated Properties");
    }

    public void RefreshRandomScoreCenterImageProperties(RefreshWorker rw)
    {
      FillPropertyRandom(Utils.Category.Sports, Utils.SubCategory.SportsManual, ref currAnyScorecenterUser, ref PrevSelectedScorecenterUser, "scorecenter.userdef", ref ListAnyScorecenterUser);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(10, "ScoreCenter Updated Properties");
    }

    public void RefreshRandomPluginsImageProperties(RefreshWorker rw)
    {
      FillPropertyRandom(Utils.Category.Plugin, Utils.SubCategory.PluginManual, ref currAnyPluginsUser, ref PrevSelectedPluginsUser, "plugins.userdef", ref ListAnyPluginsUser);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(10, "PlugIns Updated Properties");
    }

    public void RefreshRandomShowTimesImageProperties(RefreshWorker rw)
    {
      FillPropertyRandom(Utils.Category.ShowTimes, Utils.SubCategory.ShowTimesManual, ref currAnyShowTimes, ref PrevSelectedShowTimes, "showtimes", ref ListAnyShowTimes);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(10, "ShowTimes Updated Properties");
    }

    public void RefreshRandomSpotLightsImageProperties(RefreshWorker rw)
    {
      FillPropertyRandom(Utils.Category.SpotLight, Utils.SubCategory.SpotLightScraped, ref currAnySpotLights, ref PrevSelectedSpotLights, "spotlight", ref ListAnySpotLights);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(15, "SpotLights Updated Properties");
    }

    public void RefreshRandomLatestsMusicImageProperties(RefreshWorker rw)
    {
      FillPropertyLatestsRandom(Utils.Latests.Music, ref currLatestsMusic, ref PrevSelectedLatestsMusic, "music", ref ListLatestsMusic);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(20, "Music (Latests) Updated Properties");
    }

    public void RefreshRandomLatestsMvCentralImageProperties(RefreshWorker rw)
    {
      FillPropertyLatestsRandom(Utils.Latests.MvCentral, ref currLatestsMvCentral, ref PrevSelectedLatestsMvCentral, "mvcentral", ref ListLatestsMvCentral);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(20, "MvCentral (Latests) Updated Properties");
    }

    public void RefreshRandomLatestsMoviesImageProperties(RefreshWorker rw)
    {
      FillPropertyLatestsRandom(Utils.Latests.Movies, ref currLatestsMovies, ref PrevSelectedLatestsMovies, "movie", ref ListLatestsMovies);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(20, "Movies (Latests) Updated Properties");
    }

    public void RefreshRandomLatestsMovingPicturesImageProperties(RefreshWorker rw)
    {
      FillPropertyLatestsRandom(Utils.Latests.MovingPictures, ref currLatestsMovingPictures, ref PrevSelectedLatestsMovingPictures, "movingpicture", ref ListLatestsMovingPictures);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(20, "MovingPictures (Latests) Updated Properties");
    }

    public void RefreshRandomLatestsTVSeriesImageProperties(RefreshWorker rw)
    {
      FillPropertyLatestsRandom(Utils.Latests.TVSeries, ref currLatestsTVSeries, ref PrevSelectedLatestsTVSeries, "tvseries", ref ListLatestsTVSeries);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(20, "TVSeries (Latests) Updated Properties");
    }

    public void RefreshRandomLatestsMyFilmsImageProperties(RefreshWorker rw)
    {
      FillPropertyLatestsRandom(Utils.Latests.MyFilms, ref currLatestsMyFilms, ref PrevSelectedLatestsMyFilms, "myfilms", ref ListLatestsMyFilms);
      if (rw != null /*&& WindowOpen*/)
        rw.ReportProgress(20, "MyFilms (Latests) Updated Properties");
    }

    public void RefreshRandomImageProperties(RefreshWorker rw)
    {
      if (Utils.GetIsStopping())
        return;

      try
      {
        bool needRandomUpdate  = (RefreshTickCount >= Utils.MaxRefreshTickCount || RefreshTickCount == 0);
        bool needLatestsUpdate = needRandomUpdate || NeedLatestsUpdate();
        if (needRandomUpdate || needLatestsUpdate)
        {
          var stopwatch = System.Diagnostics.Stopwatch.StartNew();
          Parallel.Invoke(() => { if (needRandomUpdate) { RefreshRandomMoviesImageProperties(rw); } },
                          () => { if (needRandomUpdate) { RefreshRandomMusicImageProperties(rw); } },
                          () => { if (needRandomUpdate) { RefreshRandomTVImageProperties(rw); } },
                          () => { if (needRandomUpdate) { RefreshRandomTVSeriesImageProperties(rw); } },
                          () => { if (needRandomUpdate) { RefreshRandomPicturesImageProperties(rw); } },
                          () => { if (needRandomUpdate) { RefreshRandomGamesImageProperties(rw); } },
                          () => { if (needRandomUpdate) { RefreshRandomScoreCenterImageProperties(rw); } },
                          () => { if (needRandomUpdate) { RefreshRandomPluginsImageProperties(rw); } }, 
                          () => { if (needRandomUpdate) { RefreshRandomShowTimesImageProperties(rw); } }, 
                          () => { if (needRandomUpdate) { RefreshRandomSpotLightsImageProperties(rw); } }, 
                          //
                          () => { if (needLatestsUpdate) { RefreshRandomLatestsMusicImageProperties(rw); } },
                          () => { if (needLatestsUpdate) { RefreshRandomLatestsMvCentralImageProperties(rw); } },
                          () => { if (needLatestsUpdate) { RefreshRandomLatestsMoviesImageProperties(rw); } },
                          () => { if (needLatestsUpdate) { RefreshRandomLatestsMovingPicturesImageProperties(rw); } },
                          () => { if (needLatestsUpdate) { RefreshRandomLatestsTVSeriesImageProperties(rw); } },
                          () => { if (needLatestsUpdate) { RefreshRandomLatestsMyFilmsImageProperties(rw); } });
          stopwatch.Stop();
          // logger.Debug("Refreshing {2}{3}{4} properties is done. FanartAvailable: {1} Time elapsed: {0}.", stopwatch.Elapsed, 
          //                                                                                                  Utils.Check(FanartAvailable),
          //                                                                                                  ((needRandomUpdate) ? "Random" : ""),
          //                                                                                                  ((needRandomUpdate && needLatestsUpdate) ? "/" : ""),
          //                                                                                                  ((needLatestsUpdate) ? "Latests" : ""));
          if (needRandomUpdate)
          {
            ResetRefreshTickCount();
          }
          if (rw != null /*&& WindowOpen*/)
            rw.ReportProgress(90, "Updated Random Properties");
        }

        if (rw == null)
          return;
        rw.ReportProgress(100, "Updated Properties");
      }
      catch (Exception ex)
      {
        logger.Error("RefreshRandomImageProperties: " + ex);
      }
    }
    #endregion

    public void RefreshRandom(RefreshWorker rw, System.ComponentModel.DoWorkEventArgs e)
    {
      if (Utils.iActiveWindow == (int)GUIWindow.Window.WINDOW_INVALID)
      {
        return;
      }

      try
      {
        #region Random
        if (CheckValidWindowIDForFanart())
        {
          IsRandom = true;
          RefreshRandomImageProperties(rw);
        }
        else
        {
          EmptyAllProperties();
        }
        #endregion

        if (FanartAvailable)
        {
          IncreaseRefreshTickCount();
        }
        else
        {
          EmptyAllProperties();
        }
        if (rw != null)
          rw.Report(e);
      }
      catch (Exception ex)
      {
        logger.Error("RefreshRandom: " + ex);
      }
    }

    public void EmptyAllProperties()
    {
      if (IsRandom)
      {
        FanartIsNotAvailableRandom();
        HideImageRandom();

        FanartAvailable = false;
        EmptyAllRandomProperties();
        RefreshTickCount = 0;
        ClearPropertiesRandom();
        IsRandom = false;

        EmptyAllRandomImages();
        EmptyAllRandomLatestsImages();

        EmptyAllCurrProperties();
        EmptyAllCurrLatestsProperties();
      }
    }

    public void EmptyAllCurrProperties()
    {
      /*
      PrevSelectedGamesUser = -1;
      PrevSelectedMoviesScraper = -1;
      PrevSelectedMoviesUser = -1;
      PrevSelectedMovingPictures = -1;
      PrevSelectedMusicScraper = -1;
      PrevSelectedMusicUser = -1;
      PrevSelectedPicturesUser = -1;
      PrevSelectedPluginsUser = -1;
      PrevSelectedScorecenterUser = -1;
      PrevSelectedTVSeries = -1;
      PrevSelectedTVUser = -1;
      PrevSelectedMyFilms = -1;
      PrevSelectedShowTimes = -1;
      PrevSelectedSpotLights = -1;

      currAnyGamesUser = string.Empty;
      currAnyMoviesScraper = string.Empty;
      currAnyMoviesUser = string.Empty;
      currAnyMovingPictures = string.Empty;
      currAnyMusicScraper = string.Empty;
      currAnyMusicUser = string.Empty;
      currAnyPicturesUser = string.Empty;
      currAnyPluginsUser = string.Empty;
      currAnyScorecenterUser = string.Empty;
      currAnyTVSeries = string.Empty;
      currAnyTVUser = string.Empty;
      currAnyMyFilms = string.Empty;
      currAnyShowTimes = string.Empty;
      currAnySpotLights = string.Empty;
      */
    }

    public void EmptyAllCurrLatestsProperties()
    {
      PrevSelectedLatestsMusic = -1;
      PrevSelectedLatestsMvCentral = -1;
      PrevSelectedLatestsMovies = -1;
      PrevSelectedLatestsMovingPictures = -1;
      PrevSelectedLatestsTVSeries = -1;
      PrevSelectedLatestsMyFilms = -1;

      currLatestsMusic = string.Empty;
      currLatestsMvCentral = string.Empty;
      currLatestsMovies = string.Empty;
      currLatestsMovingPictures = string.Empty;
      currLatestsTVSeries = string.Empty;
      currLatestsMyFilms = string.Empty;
    }

    public void EmptyAllRandomImages()
    {
      Utils.EmptyAllImages(ref ListAnyGamesUser);
      Utils.EmptyAllImages(ref ListAnyMoviesUser);
      Utils.EmptyAllImages(ref ListAnyMoviesScraper);
      Utils.EmptyAllImages(ref ListAnyMovingPictures);
      Utils.EmptyAllImages(ref ListAnyMusicUser);
      Utils.EmptyAllImages(ref ListAnyMusicScraper);
      Utils.EmptyAllImages(ref ListAnyPicturesUser);
      Utils.EmptyAllImages(ref ListAnyScorecenterUser);
      Utils.EmptyAllImages(ref ListAnyTVSeries);
      Utils.EmptyAllImages(ref ListAnyTVUser);
      Utils.EmptyAllImages(ref ListAnyPluginsUser);
      Utils.EmptyAllImages(ref ListAnyMyFilms);
      Utils.EmptyAllImages(ref ListAnyShowTimes);
      Utils.EmptyAllImages(ref ListAnySpotLights);
    }

    public void EmptyAllRandomLatestsImages()
    {
      Utils.EmptyAllImages(ref ListLatestsMusic);
      Utils.EmptyAllImages(ref ListLatestsMvCentral);
      Utils.EmptyAllImages(ref ListLatestsMovies);
      Utils.EmptyAllImages(ref ListLatestsMovingPictures);
      Utils.EmptyAllImages(ref ListLatestsTVSeries);
      Utils.EmptyAllImages(ref ListLatestsMyFilms);
    }

    private bool SupportsRandomImages(Utils.Category category, Utils.SubCategory subcategory)
    {
      if (WindowsUsingFanartRandom != null)
      {
        if (Utils.iActiveWindow > (int)GUIWindow.Window.WINDOW_INVALID)
        {
          var skinFile = (SkinFile) WindowsUsingFanartRandom[Utils.sActiveWindow];
          if (skinFile != null)
          {
            if (category == Utils.Category.Game)
              return skinFile.UseRandomGamesFanartUser;
            if (category == Utils.Category.Movie)
              return skinFile.UseRandomMoviesFanartScraper; // skinFile.UseRandomMoviesFanartUser;
            if (category == Utils.Category.MovingPicture)
              return skinFile.UseRandomMovingPicturesFanart;
            if (category == Utils.Category.MusicFanart)
              return skinFile.UseRandomMusicFanartScraper; // skinFile.UseRandomMusicFanartUser;
            if (category == Utils.Category.Picture)
              return skinFile.UseRandomPicturesFanartUser;
            if (category == Utils.Category.Sports)
              return skinFile.UseRandomScoreCenterFanartUser;
            if (category == Utils.Category.TVSeries)
              return skinFile.UseRandomTVSeriesFanart;
            if (category == Utils.Category.TV)
              return skinFile.UseRandomTVFanartUser;
            if (category == Utils.Category.Plugin)
              return skinFile.UseRandomPluginsFanartUser;
            if (category == Utils.Category.MyFilms)
              return skinFile.UseRandomMyFilmsFanart;
            if (category == Utils.Category.ShowTimes)
              return skinFile.UseRandomShowTimesFanart;
            if (category == Utils.Category.SpotLight)
              return skinFile.UseRandomSpotLightsFanart;
            //
            if (subcategory == Utils.SubCategory.GameManual)
              return skinFile.UseRandomGamesFanartUser;
            if (subcategory == Utils.SubCategory.MovieManual)
              return skinFile.UseRandomMoviesFanartUser;
            if (subcategory == Utils.SubCategory.MovieScraped)
              return skinFile.UseRandomMoviesFanartScraper;
            if (subcategory == Utils.SubCategory.MovingPictureManual)
              return skinFile.UseRandomMovingPicturesFanart;
            if (subcategory == Utils.SubCategory.MusicFanartManual)
              return skinFile.UseRandomMusicFanartUser;
            if (subcategory == Utils.SubCategory.MusicFanartScraped || subcategory == Utils.SubCategory.MusicFanartAlbum)
              return skinFile.UseRandomMusicFanartScraper;
            if (subcategory == Utils.SubCategory.PictureManual)
              return skinFile.UseRandomPicturesFanartUser;
            if (subcategory == Utils.SubCategory.SportsManual)
              return skinFile.UseRandomScoreCenterFanartUser;
            if (subcategory == Utils.SubCategory.TVSeriesScraped || subcategory == Utils.SubCategory.TVSeriesManual)
              return skinFile.UseRandomTVSeriesFanart;
            if (subcategory == Utils.SubCategory.TVManual)
              return skinFile.UseRandomTVFanartUser;
            if (subcategory == Utils.SubCategory.PluginManual)
              return skinFile.UseRandomPluginsFanartUser;
            if (subcategory == Utils.SubCategory.MyFilmsManual)
              return skinFile.UseRandomMyFilmsFanart;
            if (subcategory == Utils.SubCategory.ShowTimesManual)
              return skinFile.UseRandomShowTimesFanart;
            if (subcategory == Utils.SubCategory.SpotLightScraped)
              return skinFile.UseRandomSpotLightsFanart;
          }
        }
      }
      return false;
    }

    private bool SupportsRandomLatestsImages(Utils.Latests category)
    {
      if (!Utils.LatestMediaHandlerEnabled)
      {
        return false;
      }
      if (WindowsUsingFanartLatestsRandom != null)
      {
        if (Utils.iActiveWindow > (int)GUIWindow.Window.WINDOW_INVALID)
        {
          var skinFile = (SkinFile) WindowsUsingFanartLatestsRandom[Utils.sActiveWindow];
          if (skinFile != null)
          {
            if (category == Utils.Latests.Music)
              return skinFile.UseRandomMusicLatestsFanart;
            if (category == Utils.Latests.MvCentral)
              return skinFile.UseRandomMvCentralLatestsFanart;
            if (category == Utils.Latests.Movies)
              return skinFile.UseRandomMovieLatestsFanart;
            if (category == Utils.Latests.MovingPictures)
              return skinFile.UseRandomMovingPicturesLatestsFanart;
            if (category == Utils.Latests.TVSeries)
              return skinFile.UseRandomTVSeriesLatestsFanart;
            if (category == Utils.Latests.MyFilms)
              return skinFile.UseRandomMyFilmsLatestsFanart;
          }
        }
      }
      return false;
    }

    public bool NeedLatestsUpdate()
    {
      if (!Utils.LatestMediaHandlerEnabled)
      {
        return false;
      }
      if (!Utils.ContainsID(WindowsUsingFanartLatestsRandom))
      {
        return false;
      }
      bool Result = false;
      foreach (Utils.Latests value in Enum.GetValues(typeof(Utils.Latests)))
      {
        Result = Result || NeedLatestsUpdate(value);
      }
      return Result;
    }

    public bool NeedLatestsUpdate(Utils.Latests category)
    {
      if (!Utils.LatestMediaHandlerEnabled)
      {
        return false;
      }
      if (!Utils.ContainsID(WindowsUsingFanartLatestsRandom))
      {
        return false;
      }
      return (UtilsLatestMediaHandler.GetLatestsUpdate(category) < UtilsLatestMediaHandler.GetLatestsMediaHandlerUpdate(category));
    }

    public string GetRandomFilename(ref int iFilePrev, ref string sFileNamePrev, Utils.Category category, Utils.SubCategory subcategory)
    {
      var result = string.Empty;
      // logger.Debug("*** GetRandomFilename: "+iFilePrev+" - "+sFileNamePrev+" - "+category);
      // var stopwatch = System.Diagnostics.Stopwatch.StartNew();
      try
      {
        if (!Utils.GetIsStopping())
        {
          Hashtable htAny = Utils.DBm.GetAnyFanart(category, subcategory);
          if (htAny != null)
          {
            if (htAny.Count > 0)
            {
              var htAnyValues = htAny.Values;
              result = Utils.GetFanartFilename(ref iFilePrev, ref sFileNamePrev, ref htAnyValues);
            }
          }
        }
      }
      catch (Exception ex)
      {
        logger.Error("GetRandomFilename: " + ex);
      }
      // stopwatch.Stop();
      // logger.Debug("*** GetRandomFilename: {0} -> {1}", stopwatch.Elapsed, result);
      return result;
    }

    public string GetLatestsRandomFilename(ref int iFilePrev, ref string sFileNamePrev, Utils.Latests category)
    {
      if (!Utils.LatestMediaHandlerEnabled)
      {
        return string.Empty;
      }
      var result = string.Empty;
      // logger.Debug("*** GetLatestsRandomFilename: "+iFilePrev+" - "+sFileNamePrev+" - "+category);
      // var stopwatch = System.Diagnostics.Stopwatch.StartNew();
      try
      {
        if (!Utils.GetIsStopping())
        {
          Hashtable htAny = Utils.DBm.GetAnyLatestsFanart(category);
          if (htAny != null)
          {
            if (htAny.Count > 0)
            {
              var htAnyValues = htAny.Values;
              result = Utils.GetFanartFilename(ref iFilePrev, ref sFileNamePrev, ref htAnyValues);
            }
          }
        }
      }
      catch (Exception ex)
      {
        logger.Error("GetLatestsRandomFilename: " + ex);
      }
      // stopwatch.Stop();
      // logger.Debug("*** GetLatestsRandomFilename: {0} -> {1}", stopwatch.Elapsed, result);
      return result;
    }

    public void RefreshRandomFilenames(bool FullUpdate = true)
    {
      int sync = Interlocked.CompareExchange(ref SyncPoinRandomUpdate, 1, 0);
      if (sync != 0)
      {
        return;
      }

      // var stopwatch = System.Diagnostics.Stopwatch.StartNew();
      try
      {
        Parallel.Invoke(() => { Utils.DBm.RefreshAnyFanart(Utils.Category.Picture, Utils.SubCategory.PictureManual, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyFanart(Utils.Category.Movie, Utils.SubCategory.MovieManual, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyFanart(Utils.Category.Movie, Utils.SubCategory.MovieScraped, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyFanart(Utils.Category.MusicFanart, Utils.SubCategory.MusicFanartManual, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyFanart(Utils.Category.MusicFanart, Utils.SubCategory.MusicFanartScraped, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyFanart(Utils.Category.TVSeries, Utils.SubCategory.TVSeriesScraped, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyFanart(Utils.Category.MovingPicture, Utils.SubCategory.MovingPictureManual, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyFanart(Utils.Category.TV, Utils.SubCategory.TVManual, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyFanart(Utils.Category.Game, Utils.SubCategory.GameManual, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyFanart(Utils.Category.Sports, Utils.SubCategory.SportsManual, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyFanart(Utils.Category.Plugin, Utils.SubCategory.PluginManual, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyFanart(Utils.Category.MyFilms, Utils.SubCategory.MyFilmsManual, FullUpdate); }, 
                        () => { Utils.DBm.RefreshAnyFanart(Utils.Category.ShowTimes, Utils.SubCategory.ShowTimesManual, FullUpdate); }, 
                        () => { Utils.DBm.RefreshAnyFanart(Utils.Category.SpotLight, Utils.SubCategory.SpotLightScraped, FullUpdate); });
      }
      catch { }
      // stopwatch.Stop();
      // logger.Debug("Refreshing Any Random filenames hashtable is done. Time elapsed: {0}.", stopwatch.Elapsed);
      SyncPoinRandomUpdate = 0;
    }

    public void RefreshRandomLatestsFilenames(bool FullUpdate = true)
    {
      if (!Utils.LatestMediaHandlerEnabled)
      {
        return;
      }
      int sync = Interlocked.CompareExchange(ref SyncPoinRandomLatestsUpdate, 1, 0);
      if (sync != 0)
      {
        return;
      }

      // var stopwatch = System.Diagnostics.Stopwatch.StartNew();
      try
      {
        Parallel.Invoke(() => { Utils.DBm.RefreshAnyLatestsFanart(Utils.Latests.Music, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyLatestsFanart(Utils.Latests.MvCentral, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyLatestsFanart(Utils.Latests.Movies, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyLatestsFanart(Utils.Latests.MovingPictures, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyLatestsFanart(Utils.Latests.TVSeries, FullUpdate); },
                        () => { Utils.DBm.RefreshAnyLatestsFanart(Utils.Latests.MyFilms, FullUpdate); });
      }
      catch { }
      // stopwatch.Stop();
      // logger.Debug("Refreshing Any Latests Random filenames hashtable is done. Time elapsed: {0}.", stopwatch.Elapsed);
      SyncPoinRandomLatestsUpdate = 0;
    }

    private void IncreaseRefreshTickCount()
    {
      RefreshTickCount = checked (RefreshTickCount + 1);
    }

    public void ResetRefreshTickCount()
    {
      RefreshTickCount = 0;
    }

    public void ForceRefreshTickCount()
    {
      RefreshTickCount = Utils.MaxRefreshTickCount;
    }

    public int GetPropertiesRandomCount()
    {
      if (propertiesRandom == null)
        return 0;
      else
        return propertiesRandom.Count;
    }

    public void UpdateProperties()
    {
      Utils.UpdateProperties(ref propertiesRandom);
    }

    public void ClearPropertiesRandom()
    {
      if (propertiesRandom == null)
        return;
      lock (propertiesRandom)
        propertiesRandom.Clear();
    }

    private void FillPropertyRandom(Utils.Category category, Utils.SubCategory subcategory, ref string prevImage, ref int iFilePrev, string propertyname, ref ArrayList al)
    {
      // var stopwatch = System.Diagnostics.Stopwatch.StartNew();
      var randomFilename = string.Empty;
      if (SupportsRandomImages(category, subcategory))
      {
        randomFilename = GetRandomFilename(ref iFilePrev, ref prevImage, category, subcategory);
      }
      else
      {
        Utils.EmptyAllImages(ref al);
      }

      var propAvail = propertyname + ".random.available";
      propertyname  = propertyname + ".backdrop";
      if (!string.IsNullOrEmpty(randomFilename))
      {
        lock (propertiesRandom)
          Utils.AddProperty(ref propertiesRandom, propertyname + (DoShowImageOneRandom ? "1" : "2") + ".any", randomFilename, ref al);
        // logger.Debug("*** FillPropertyRandom: {0} - {1}", propertyname + (DoShowImageOneRandom ? "1" : "2") + ".any", randomFilename);

        var property = Utils.GetProperty(propertyname + (DoShowImageOneRandom ? "2" : "1") + ".any");
        if (property == null || property.Length < 2 || property.EndsWith("transparent.png", StringComparison.CurrentCulture))
        {
          lock (propertiesRandom)
            Utils.AddProperty(ref propertiesRandom, propertyname + (DoShowImageOneRandom ? "2" : "1") + ".any", randomFilename, ref al);
          // logger.Debug("*** FillPropertyRandom: {0} - {1}", propertyname + (DoShowImageOneRandom ? "2" : "1") + ".any", randomFilename);
        }
        FanartAvailable = FanartAvailable || true;
        Utils.SetProperty(propAvail, "true");
      }
      else
      {
        // logger.Debug("*** FillPropertyRandom: {0} - empty", propertyname + "1&2.any");
        Utils.SetProperty(propertyname + "1.any", string.Empty);
        Utils.SetProperty(propertyname + "2.any", string.Empty);
        iFilePrev = -1;
        FanartAvailable = FanartAvailable || false;
        Utils.SetProperty(propAvail, "false");
      }
      // stopwatch.Stop();
      // logger.Debug("*** FillPropertyRandom: {0}", stopwatch.Elapsed);
    }

    private void FillPropertyLatestsRandom(Utils.Latests category, ref string prevImage, ref int iFilePrev, string propertyname, ref ArrayList al)
    {
      // var stopwatch = System.Diagnostics.Stopwatch.StartNew();
      var randomFilename = string.Empty;
      if (SupportsRandomLatestsImages(category))
      {
        randomFilename = GetLatestsRandomFilename(ref iFilePrev, ref prevImage, category);
      }
      else
      {
        Utils.EmptyAllImages(ref al);
      }

      var propAvail = propertyname + ".latests.available";
      propertyname  = propertyname + ".latests.backdrop";
      if (!string.IsNullOrEmpty(randomFilename))
      {
        lock (propertiesRandom)
          Utils.AddProperty(ref propertiesRandom, propertyname + (DoShowImageOneRandom ? "1" : "2") + ".any", randomFilename, ref al);
        // logger.Debug("*** FillPropertyLatestsRandom: {0} - {1}", propertyname + (DoShowImageOneRandom ? "1" : "2") + ".any", randomFilename);

        var property = Utils.GetProperty(propertyname + (DoShowImageOneRandom ? "2" : "1") + ".any");
        if (property == null || property.Length < 2 || property.EndsWith("transparent.png", StringComparison.CurrentCulture))
        {
          lock (propertiesRandom)
            Utils.AddProperty(ref propertiesRandom, propertyname + (DoShowImageOneRandom ? "2" : "1") + ".any", randomFilename, ref al);
          // logger.Debug("*** FillPropertyLatestsRandom: {0} - {1}", propertyname + (DoShowImageOneRandom ? "2" : "1") + ".any", randomFilename);
        }
        FanartAvailable = FanartAvailable || true;
        Utils.SetProperty(propAvail, "true");
      }
      else
      {
        // logger.Debug("*** FillPropertyLatestsRandom: {0} - empty", propertyname + "1&2.any");
        Utils.SetProperty(propertyname + "1.any", string.Empty);
        Utils.SetProperty(propertyname + "2.any", string.Empty);
        iFilePrev = -1;
        FanartAvailable = FanartAvailable || false;
        Utils.SetProperty(propAvail, "false");
      }
      // stopwatch.Stop();
      // logger.Debug("*** FillPropertyLatestsRandom: {0}", stopwatch.Elapsed);
    }

    public void EmptyRandomGamesProperties()
    {
      Utils.SetProperty("games.userdef.random.available", string.Empty);
      Utils.SetProperty("games.userdef.backdrop1.any", string.Empty);
      Utils.SetProperty("games.userdef.backdrop2.any", string.Empty);
    }

    public void EmptyRandomMoviesProperties()
    {
      Utils.SetProperty("movie.userdef.random.available", string.Empty);
      Utils.SetProperty("movie.userdef.backdrop1.any", string.Empty);
      Utils.SetProperty("movie.userdef.backdrop2.any", string.Empty);

      Utils.SetProperty("movie.scraper.random.available", string.Empty);
      Utils.SetProperty("movie.scraper.backdrop1.any", string.Empty);
      Utils.SetProperty("movie.scraper.backdrop2.any", string.Empty);
    }

    public void EmptyRandomMisicProperties()
    {
      Utils.SetProperty("music.userdef.random.available", string.Empty);
      Utils.SetProperty("music.userdef.backdrop1.any", string.Empty);
      Utils.SetProperty("music.userdef.backdrop2.any", string.Empty);

      Utils.SetProperty("music.scraper.random.available", string.Empty);
      Utils.SetProperty("music.scraper.backdrop1.any", string.Empty);
      Utils.SetProperty("music.scraper.backdrop2.any", string.Empty);
    }

    public void EmptyRandomPicturesProperties()
    {
      Utils.SetProperty("picture.userdef.random.available", string.Empty);
      Utils.SetProperty("picture.userdef.backdrop1.any", string.Empty);
      Utils.SetProperty("picture.userdef.backdrop2.any", string.Empty);
    }

    public void EmptyRandomScorecenterProperties()
    {
      Utils.SetProperty("scorecenter.userdef.random.available", string.Empty);
      Utils.SetProperty("scorecenter.userdef.backdrop1.any", string.Empty);
      Utils.SetProperty("scorecenter.userdef.backdrop2.any", string.Empty);
    }

    public void EmptyRandomShowTimesProperties()
    {
      Utils.SetProperty("showtimes.random.available", string.Empty);
      Utils.SetProperty("showtimes.backdrop1.any", string.Empty);
      Utils.SetProperty("showtimes.backdrop2.any", string.Empty);
    }

    public void EmptyRandomTVProperties()
    {
      Utils.SetProperty("tv.userdef.random.available", string.Empty);
      Utils.SetProperty("tv.userdef.backdrop1.any", string.Empty);
      Utils.SetProperty("tv.userdef.backdrop2.any", string.Empty);
    }

    public void EmptyRandomPluginsProperties()
    {
      Utils.SetProperty("plugins.userdef.random.available", string.Empty);
      Utils.SetProperty("plugins.userdef.backdrop1.any", string.Empty);
      Utils.SetProperty("plugins.userdef.backdrop2.any", string.Empty);
    }

    public void EmptyRandomMovingPicturesProperties()
    {
      Utils.SetProperty("movingpicture.random.available", string.Empty);
      Utils.SetProperty("movingpicture.backdrop1.any", string.Empty);
      Utils.SetProperty("movingpicture.backdrop2.any", string.Empty);
    }

    public void EmptyRandomTVSeriesProperties()
    {
      Utils.SetProperty("tvseries.random.available", string.Empty);
      Utils.SetProperty("tvseries.backdrop1.any", string.Empty);
      Utils.SetProperty("tvseries.backdrop2.any", string.Empty);
    }

    public void EmptyRandomMyFilmsProperties()
    {
      Utils.SetProperty("myfilms.random.available", string.Empty);
      Utils.SetProperty("myfilms.backdrop1.any", string.Empty);
      Utils.SetProperty("myfilms.backdrop2.any", string.Empty);
    }

    public void EmptyRandomSpotLightsProperties()
    {
      Utils.SetProperty("spotlight.random.available", string.Empty);
      Utils.SetProperty("spotlight.backdrop1.any", string.Empty);
      Utils.SetProperty("spotlight.backdrop2.any", string.Empty);
    }

    public void EmptyRandomMisicLatestsProperties()
    {
      Utils.SetProperty("music.latests.available", string.Empty);
      Utils.SetProperty("music.latests.backdrop1.any", string.Empty);
      Utils.SetProperty("music.latests.backdrop2.any", string.Empty);
    }

    public void EmptyRandomMvCentralLatestsProperties()
    {
      Utils.SetProperty("mvcentral.latests.available", string.Empty);
      Utils.SetProperty("mvcentral.latests.backdrop1.any", string.Empty);
      Utils.SetProperty("mvcentral.latests.backdrop2.any", string.Empty);
    }

    public void EmptyRandomMoviesLatestsProperties()
    {
      Utils.SetProperty("movie.latests.available", string.Empty);
      Utils.SetProperty("movie.latests.backdrop1.any", string.Empty);
      Utils.SetProperty("movie.latests.backdrop2.any", string.Empty);
    }

    public void EmptyRandomMovingPicturesLatestsProperties()
    {
      Utils.SetProperty("movingpicture.latests.available", string.Empty);
      Utils.SetProperty("movingpicture.latests.backdrop1.any", string.Empty);
      Utils.SetProperty("movingpicture.latests.backdrop2.any", string.Empty);
    }

    public void EmptyRandomTVSeriesLatestsProperties()
    {
      Utils.SetProperty("tvseries.latests.available", string.Empty);
      Utils.SetProperty("tvseries.latests.backdrop1.any", string.Empty);
      Utils.SetProperty("tvseries.latests.backdrop2.any", string.Empty);
    }

    public void EmptyRandomMyFilmsLatestsProperties()
    {
      Utils.SetProperty("myfilms.latests.available", string.Empty);
      Utils.SetProperty("myfilms.latests.backdrop1.any", string.Empty);
      Utils.SetProperty("myfilms.latests.backdrop2.any", string.Empty);
    }

    public void EmptyAllRandomProperties()
    {
      if ((Utils.DBm.HtAnyFanart != null) && (Utils.DBm.HtAnyFanart.Count > 0))
      {
        return;
      }

      EmptyRandomMoviesProperties();
      EmptyRandomMisicProperties();
      EmptyRandomPicturesProperties();
      EmptyRandomTVSeriesProperties();
      EmptyRandomTVProperties();
      EmptyRandomGamesProperties();
      EmptyRandomScorecenterProperties();
      EmptyRandomPluginsProperties();
      EmptyRandomMovingPicturesProperties();
      EmptyRandomMyFilmsProperties();
      EmptyRandomShowTimesProperties();
      EmptyRandomSpotLightsProperties();

      EmptyRandomMisicLatestsProperties();
      EmptyRandomMvCentralLatestsProperties();
      EmptyRandomMoviesLatestsProperties();
      EmptyRandomMovingPicturesLatestsProperties();
      EmptyRandomTVSeriesLatestsProperties();
      EmptyRandomMyFilmsLatestsProperties();
    }

    public void ShowImageRandom()
    {
      if (FanartAvailable)
      {
        FanartIsAvailableRandom();
        if (DoShowImageOneRandom)
        {
          ShowImageOneRandom();
        }
        else
        {
          ShowImageTwoRandom();
        }
      }
      else
      {
        FanartIsNotAvailableRandom();
        HideImageRandom();
      }
    }

    public void HideImageRandom()
    {
      if ((Utils.iActiveWindow > (int)GUIWindow.Window.WINDOW_INVALID) && (ControlImageVisible != 0))
      {
        Utils.HideControl(Utils.iActiveWindow, 91919297);
        Utils.HideControl(Utils.iActiveWindow, 91919298);
        DoShowImageOneRandom = true;
        ControlImageVisible = 0;
        // logger.Debug("*** Random hide all images - 91919297, 91919298");
      }
    }

    public void FanartIsAvailableRandom()
    {
      if ((Utils.iActiveWindow > (int)GUIWindow.Window.WINDOW_INVALID) && (ControlVisible != 1))
      {
        Utils.ShowControl(Utils.iActiveWindow, 91919299);
        ControlVisible = 1;
        // logger.Debug("*** Random fanart available - 91919299");
      }
    }

    public void FanartIsNotAvailableRandom()
    {
      if ((Utils.iActiveWindow > (int)GUIWindow.Window.WINDOW_INVALID) && (ControlVisible != 0))
      {
        Utils.HideControl(Utils.iActiveWindow, 91919299);
        ControlVisible = 0;
        // logger.Debug("*** Random fanart not available - 91919299");
      }
    }

    public void ShowImageOneRandom()
    {
      if (Utils.iActiveWindow > (int)GUIWindow.Window.WINDOW_INVALID)
      {
        Utils.ShowControl(Utils.iActiveWindow, 91919297);
        Utils.HideControl(Utils.iActiveWindow, 91919298);
        DoShowImageOneRandom = false;
        ControlImageVisible = 1;
        // logger.Debug("*** Random show image 1 - 91919297");
      }
      else
      {
        RefreshTickCount = 0;
      }
    }

    public void ShowImageTwoRandom()
    {
      if (Utils.iActiveWindow > (int)GUIWindow.Window.WINDOW_INVALID)
      {
        Utils.ShowControl(Utils.iActiveWindow, 91919298);
        Utils.HideControl(Utils.iActiveWindow, 91919297);
        DoShowImageOneRandom = true;
        ControlImageVisible = 1;
        // logger.Debug("*** Random show image 2 - 91919298");
      }
      else
      {
        RefreshTickCount = 0;
      }
    }

    public class SkinFile
    {
      public bool UseRandomGamesFanartUser = false; 
      public bool UseRandomMoviesFanartScraper = false;
      public bool UseRandomMoviesFanartUser = false;
      public bool UseRandomMovingPicturesFanart = false;
      public bool UseRandomMusicFanartScraper = false;
      public bool UseRandomMusicFanartUser = false;
      public bool UseRandomPicturesFanartUser = false;
      public bool UseRandomPluginsFanartUser = false;
      public bool UseRandomScoreCenterFanartUser = false;
      public bool UseRandomTVFanartUser = false;
      public bool UseRandomTVSeriesFanart = false;
      public bool UseRandomMyFilmsFanart = false;
      public bool UseRandomShowTimesFanart = false;

      public bool UseRandomMusicLatestsFanart = false;
      public bool UseRandomMvCentralLatestsFanart = false;
      public bool UseRandomMovieLatestsFanart = false;
      public bool UseRandomMovingPicturesLatestsFanart = false;
      public bool UseRandomTVSeriesLatestsFanart = false;
      public bool UseRandomMyFilmsLatestsFanart = false;

      public bool UseRandomSpotLightsFanart = false;
    }
  }
}
