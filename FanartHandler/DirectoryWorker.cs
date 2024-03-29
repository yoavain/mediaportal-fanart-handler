﻿// Type: FanartHandler.DirectoryWorker
// Assembly: FanartHandler, Version=4.0.3.0, Culture=neutral, PublicKeyToken=null
// MVID: 073E8D78-B6AE-4F86-BDE9-3E09A337833B

extern alias FHNLog;

using MediaPortal.Configuration;

using FHNLog.NLog;

using System;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace FanartHandler
{
  internal class DirectoryWorker : BackgroundWorker
  {
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    private string type;

    static DirectoryWorker()
    {
    }

    public DirectoryWorker()
    {
      WorkerReportsProgress = true;
      WorkerSupportsCancellation = true;
    }

    protected override void OnDoWork(DoWorkEventArgs e)
    {
      var All = false;

      if (!Utils.GetIsStopping())
      {
        try
        {
          Utils.ThreadToLongSleep();

          Thread.CurrentThread.Priority = FanartHandlerSetup.Fh.FHThreadPriority != Utils.Priority.Lowest ? ThreadPriority.BelowNormal : ThreadPriority.Lowest;
          Thread.CurrentThread.Name = "DirectoryWorker";
          Utils.AllocateDelayStop("DirectoryWorker-OnDoWork");

          Utils.SetProperty("directory.scan", "true");
          logger.Info("Refreshing local fanart is starting...");
          //
          var strArray = e.Argument as string[];
          if (strArray != null)
          {
            string Folder = strArray[0].Trim();
            if (strArray.Length == 2)
            { 
              type = strArray[1];
            }
            All = Folder.Equals("All");

            if(!All && Utils.IsJunction)
            {
              if (Folder.Contains(Utils.JunctionTarget, StringComparison.OrdinalIgnoreCase))
              {
                var str = Folder.Replace(Utils.JunctionTarget, Utils.JunctionSource);
                logger.Debug("Revert junction: "+Folder+" -> "+str);
                Folder = str;
              }
            }
            //
            ReportProgress(0, "Importing local fanart for Weather...");
            if (All || Folder.Contains(Utils.FAHUDWeather, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for Weather is starting.");
              Utils.SetupFilenames(Utils.FAHUDWeather, "*.jpg", Utils.Category.Weather, Utils.SubCategory.None, null, Utils.Provider.Local);
              // Utils.DBm.RemoveFromAnyHashtable(Utils.Category.Weather);
              Utils.DBm.RefreshAnyFanart(Utils.Category.Weather, Utils.SubCategory.None, false);
              logger.Info("Refreshing local fanart for Weather is done.");
            }
            ReportProgress(2, "Importing local fanart for Holidays...");
            if (All || Folder.Contains(Utils.FAHUDHoliday, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for Holiday is starting.");
              Utils.SetupFilenames(Utils.FAHUDHoliday, "*.jpg", Utils.Category.Holiday, Utils.SubCategory.None, null, Utils.Provider.Local);
              // Utils.DBm.RemoveFromAnyHashtable(Utils.Category.Weather);
              Utils.DBm.RefreshAnyFanart(Utils.Category.Holiday, Utils.SubCategory.None, false);
              logger.Info("Refreshing local fanart for Holiday is done.");
            }
            ReportProgress(4, "Importing local fanart for Pictures...");
            if (All || Folder.Contains(Utils.FAHUDPictures, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for Pictures is starting.");
              Utils.SetupFilenames(Utils.FAHUDPictures, "*.jpg", Utils.Category.Picture, Utils.SubCategory.PictureManual, null, Utils.Provider.Local);
              // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.PictureManual);
              Utils.DBm.RefreshAnyFanart(Utils.Category.Picture, Utils.SubCategory.PictureManual, false);
              logger.Info("Refreshing local fanart for Pictures is done.");
            }
            ReportProgress(10, "Importing local fanart for Movies (User)...");
            if (All || Folder.Contains(Utils.FAHUDMovies, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for Movies (User) is starting.");
              Utils.SetupFilenames(Utils.FAHUDMovies, "*.jpg", Utils.Category.Movie, Utils.SubCategory.MovieManual, null, Utils.Provider.Local);
              // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.MovieManual);
              Utils.DBm.RefreshAnyFanart(Utils.Category.Movie, Utils.SubCategory.MovieManual, false);
              logger.Info("Refreshing local fanart for Movies (User) is done.");
            }
            ReportProgress(16, "Importing local fanart for Movies (Scraper)...");
            if (All || Folder.Contains(Utils.FAHSMovies, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for Movies (Scraper) is starting.");
              Utils.SetupFilenames(Utils.FAHSMovies, "*.jpg", Utils.Category.Movie, Utils.SubCategory.MovieScraped, null, Utils.Provider.MyVideos);
              // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.MovieScraped);
              Utils.DBm.RefreshAnyFanart(Utils.Category.Movie, Utils.SubCategory.MovieScraped, false);
              logger.Info("Refreshing local fanart for Movies (Scraper) is done.");
            }
            ReportProgress(22, "Importing local fanart for Music (Albums)...");
            if (All || Folder.Contains(Utils.FAHMusicAlbums, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for Music (Albums) is starting.");
              Utils.SetupFilenames(Utils.FAHMusicAlbums, "*L.jpg", Utils.Category.MusicAlbum, Utils.SubCategory.MusicAlbumThumbScraped, null, Utils.Provider.Local);
              Utils.DBm.RemoveFromAnyHashtable(Utils.Category.MusicAlbum, Utils.SubCategory.MusicAlbumThumbScraped);
              // Utils.DBm.RefreshAnyFanart(Utils.SubCategory.MusicAlbumThumbScraped, false);
              logger.Info("Refreshing local fanart for Music Albums is done.");
            }
            ReportProgress(28, "Importing local fanart for Music (Artists)...");
            if (All || Folder.Contains(Utils.FAHMusicArtists, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for Music (Artists) is starting.");
              Utils.SetupFilenames(Utils.FAHMusicArtists, "*L.jpg", Utils.Category.MusicArtist, Utils.SubCategory.MusicArtistThumbScraped, null, Utils.Provider.Local);
              Utils.DBm.RemoveFromAnyHashtable(Utils.Category.MusicArtist, Utils.SubCategory.MusicArtistThumbScraped);
              // Utils.DBm.RefreshAnyFanart(Utils.SubCategory.MusicArtistThumbScraped, false);
              logger.Info("Refreshing local fanart for Music Artists is done.");
            }
            ReportProgress(34, "Importing local fanart for Music (User)...");
            if (All || Folder.Contains(Utils.FAHUDMusic, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for Music (User) is starting.");
              Utils.SetupFilenames(Utils.FAHUDMusic, "*.jpg", Utils.Category.MusicFanart, Utils.SubCategory.MusicFanartManual, null, Utils.Provider.Local);
              // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.MusicFanartManual);
              Utils.DBm.RefreshAnyFanart(Utils.Category.MusicFanart, Utils.SubCategory.MusicFanartManual, false);
              logger.Info("Refreshing local fanart for Music (User) is done.");
            }
            ReportProgress(40, "Importing local fanart for Music (User Album)...");
            if (All || Folder.Contains(Utils.FAHUDMusicAlbum, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for Music (User Album) is starting.");
              Utils.SetupFilenames(Utils.FAHUDMusicAlbum, "*.jpg", Utils.Category.MusicFanart, Utils.SubCategory.MusicFanartAlbum, null, Utils.Provider.Local);
              Utils.DBm.RemoveFromAnyHashtable(Utils.Category.MusicFanart, Utils.SubCategory.MusicFanartAlbum);
              // Utils.DBm.RefreshAnyFanart(Utils.SubCategory.MusicFanartAlbum, false);
              logger.Info("Refreshing local fanart for Music (User Album) is done.");
            }
            /*
            ReportProgress(46, "Importing local fanart for Music (User Genre)...");
            if (All || Folder.Contains(Utils.FAHUDMusicGenre, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for Music (User Genre) is starting.");
              Utils.SetupFilenames(Utils.FAHUDMusicGenre, "*.jpg", Utils.SubCategory.MusicFanartManual, null, Utils.Provider.Local);
              // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.MusicFanartManual);
              Utils.DBm.RefreshAnyFanart(Utils.SubCategory.MusicFanartManual, false);
              logger.Info("Refreshing local fanart for Music (User Genre) is done.");
            }
            */
            ReportProgress(52, "Importing local fanart for Music (Scraper)...");
            if (All || Folder.Contains(Utils.FAHSMusic, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for Music (Scraper) is starting.");
              Utils.SetupFilenames(Utils.FAHSMusic, "*.jpg", Utils.Category.MusicFanart, Utils.SubCategory.MusicFanartScraped, null, Utils.Provider.Local);
              // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.MusicFanartScraped);
              Utils.DBm.RefreshAnyFanart(Utils.Category.MusicFanart, Utils.SubCategory.MusicFanartScraped, false);
              logger.Info("Refreshing local fanart for Music (Scraper) is done.");
            }
            ReportProgress(58, "Importing local fanart for Music (Folder)...");
            if (All && Utils.ScanMusicFoldersForFanart && !string.IsNullOrEmpty(Utils.MusicFoldersArtistAlbumRegex))
            {
              Utils.ScanMusicFoldersForFanarts();
            }
            ReportProgress(64, "Importing local fanart for Games...");
            if (All || Folder.Contains(Utils.FAHUDGames, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for Games is starting.");
              Utils.SetupFilenames(Utils.FAHUDGames, "*.jpg", Utils.Category.Game, Utils.SubCategory.GameManual, null, Utils.Provider.Local);
              // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.GameManual);
              Utils.DBm.RefreshAnyFanart(Utils.Category.Game, Utils.SubCategory.GameManual, false);
              logger.Info("Refreshing local fanart for Games is done.");
            }
            ReportProgress(70, "Importing local fanart for Scorecenter...");
            if (All || Folder.Contains(Utils.FAHUDScorecenter, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for ScoreCenter is starting.");
              Utils.SetupFilenames(Utils.FAHUDScorecenter, "*.jpg", Utils.Category.Sports, Utils.SubCategory.SportsManual, null, Utils.Provider.Local);
              // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.SportsManual);
              Utils.DBm.RefreshAnyFanart(Utils.Category.Sports, Utils.SubCategory.SportsManual, false);
              logger.Info("Refreshing local fanart for ScoreCenter is done.");
            }
            ReportProgress(76, "Importing local fanart for TV...");
            if (All || Folder.Contains(Utils.FAHUDTV, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for TV is starting.");
              Utils.SetupFilenames(Utils.FAHUDTV, "*.jpg", Utils.Category.TV, Utils.SubCategory.TVManual, null, Utils.Provider.Local);
              // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.TVManual);
              Utils.DBm.RefreshAnyFanart(Utils.Category.TV, Utils.SubCategory.TVManual, false);
              logger.Info("Refreshing local fanart for TV is done.");
            }
            ReportProgress(82, "Importing local fanart for Plugins...");
            if (All || Folder.Contains(Utils.FAHUDPlugins, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for Plugins is starting.");
              Utils.SetupFilenames(Utils.FAHUDPlugins, "*.jpg", Utils.Category.Plugin, Utils.SubCategory.PluginManual, null, Utils.Provider.Local);
              // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.PluginManual);
              Utils.DBm.RefreshAnyFanart(Utils.Category.Plugin, Utils.SubCategory.PluginManual, false);
              logger.Info("Refreshing local fanart for Plugins is done.");
            }
            ReportProgress(88, "Importing local fanart for TVSeries...");
            if (Utils.TVSeriesEnabled && 
                (FanartHandlerHelper.IsAssemblyAvailable("MP-TVSeries", new Version(4, 0, 0, 0), Path.Combine(Path.Combine(Config.GetFolder((Config.Dir) 5), "windows"), "MP-TVSeries.dll")) && 
                (All || Folder.Equals("TVSeries") || Folder.Contains(Utils.FAHTVSeries, StringComparison.OrdinalIgnoreCase))))
            {
              logger.Info("Refreshing local fanart for TVSeries is starting.");
              try
              {
                var tvSeriesName = UtilsTVSeries.GetTVSeriesNames(Utils.Category.TVSeries, Utils.SubCategory.TVSeriesScraped);
                if (tvSeriesName != null)
                {
                  Utils.SetupFilenames(Utils.FAHTVSeries, "*.jpg", Utils.Category.TVSeries, Utils.SubCategory.TVSeriesScraped, tvSeriesName, Utils.Provider.TVSeries);
                  logger.Info("Refreshing local fanart for TVSeries added files.");
                  tvSeriesName.Clear();
                  // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.TVSeriesScraped);
                  Utils.DBm.RefreshAnyFanart(Utils.Category.TVSeries, Utils.SubCategory.TVSeriesScraped, false);
                }
              }
              catch { }
              logger.Info("Refreshing local fanart for TVSeries is done.");
            }
            ReportProgress(94, "Importing local fanart for MovingPictures...");
            if (Utils.MovingPicturesEnabled && 
                (FanartHandlerHelper.IsAssemblyAvailable("MovingPictures", new Version(1, 0, 0, 0), Path.Combine(Path.Combine(Config.GetFolder((Config.Dir) 5), "windows"), "MovingPictures.dll")) &&
                (All || Folder.Equals("MovingPictures") || Folder.Contains(Utils.FAHMovingPictures, StringComparison.OrdinalIgnoreCase))))
            {
              logger.Info("Refreshing local fanart for MovingPictures is starting.");
              try
              {
                UtilsMovingPictures.GetMovingPicturesBackdrops();
                // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.MovingPictureManual);
                Utils.DBm.RefreshAnyFanart(Utils.Category.MovingPicture, Utils.SubCategory.MovingPictureManual, false);
              }
              catch { }
              logger.Info("Refreshing local fanart for MovingPictures is done.");
            }
            ReportProgress(96, "Importing local fanart for MyFilms...");
            if (Utils.MyFilmsEnabled && 
                (FanartHandlerHelper.IsAssemblyAvailable("MyFilms", new Version(6, 0, 0, 0), Path.Combine(Path.Combine(Config.GetFolder((Config.Dir) 5), "windows"), "MyFilms.dll")) &&
                (All || Folder.Equals("MyFilms") || Folder.Contains(Utils.FAHMyFilms, StringComparison.OrdinalIgnoreCase))))
            {
              logger.Info("Refreshing local fanart for MyFilms is starting.");
              try
              {
                UtilsMyFilms.GetMyFilmsBackdrops();
                // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.MyFilmsManual);
                Utils.DBm.RefreshAnyFanart(Utils.Category.MyFilms, Utils.SubCategory.MyFilmsManual, false);
              }
              catch { }
              logger.Info("Refreshing local fanart for MyFilms is done.");
            }
            ReportProgress(98, "Importing local fanart for ShowTimes...");
            if (All || Folder.Contains(Utils.FAHShowTimes, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for ShowTimes is starting.");
              Utils.SetupFilenames(Utils.FAHShowTimes, "*.jpg", Utils.Category.ShowTimes, Utils.SubCategory.ShowTimesManual, null, Utils.Provider.Local);
              // Utils.DBm.RemoveFromAnyHashtable(Utils.SubCategory.ShowTimesManual);
              Utils.DBm.RefreshAnyFanart(Utils.Category.ShowTimes, Utils.SubCategory.ShowTimesManual, false);
              logger.Info("Refreshing local fanart for ShowTimes is done.");
            }
            ReportProgress(99, "Importing fanart for SpotLight...");
            if (All || Folder.Contains(Utils.W10SpotLight, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing Windows fanart for SpotLight is starting.");
              Utils.SetupW10SpotLights();
              Utils.SetupFilenames(Utils.FAHSSpotLight, "*.jpg", Utils.Category.SpotLight, Utils.SubCategory.SpotLightScraped, null, Utils.Provider.SpotLight);
              Utils.DBm.CleanRedundantFanart(Utils.Category.SpotLight, Utils.SubCategory.SpotLightScraped, Utils.SpotLightMax);
              Utils.DBm.RefreshAnyFanart(Utils.Category.SpotLight, Utils.SubCategory.SpotLightScraped, false);
              logger.Info("Refreshing Windows fanart for SpotLight is done.");
            }
            if (All || Folder.Contains(Utils.FAHSSpotLight, StringComparison.OrdinalIgnoreCase))
            {
              logger.Info("Refreshing local fanart for SpotLight is starting.");
              Utils.SetupFilenames(Utils.FAHSSpotLight, "*.jpg", Utils.Category.SpotLight, Utils.SubCategory.SpotLightScraped, null, Utils.Provider.SpotLight);
              Utils.DBm.CleanRedundantFanart(Utils.Category.SpotLight, Utils.SubCategory.SpotLightScraped, Utils.SpotLightMax);
              Utils.DBm.RefreshAnyFanart(Utils.Category.SpotLight, Utils.SubCategory.SpotLightScraped, false);
              logger.Info("Refreshing local fanart for SpotLight is done.");
            }
          }
        }
        catch (Exception ex)
        {
          logger.Error("OnDoWork: " + ex);
        }
      }
      ReportProgress(100, "Done / Idle");
      Utils.ThreadToLongSleep();
      ReportProgress(0, "Done / Idle");
      e.Result = 0;
    }

    internal void OnProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      try
      {
        if (Utils.GetIsStopping() || type == null)
          return;

        if (!type.Equals("All") && !type.Equals("Fanart") && (!type.Equals("Thumbs") && !type.Equals("External")))
          return;

        // FanartHandlerConfig F = new FanartHandlerConfig();

        FanartHandlerSetup.FhC.StripStatusLabelToolTipText = e.UserState.ToString();
        FanartHandlerSetup.FhC.StripProgressBarValue = e.ProgressPercentage;

        Utils.ThreadToSleep();
      }
      catch (Exception ex)
      {
        logger.Error("OnProgressChanged: " + ex);
      }
    }

    internal void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      var flag = false;

      try
      {
        Utils.SetProperty("directory.scan", "false");
        // FanartHandlerSetup.Fh.FRandom.RefreshRandomFilenames(false);

        Utils.ReleaseDelayStop("DirectoryWorker-OnDoWork");
        FanartHandlerSetup.Fh.SyncPointDirectory = 0;
        logger.Info("Refreshing local fanart is done.");

        if (type == null)
          return;

        // FanartHandlerConfig F = new FanartHandlerConfig();

        if (type.Equals("All") || type.Equals("Fanart"))
        {
          FanartHandlerSetup.FhC.UpdateFanartTableOnStartup(0);
          flag = true;
        }
        if (type.Equals("All") || type.Equals("Thumbs"))
        {
          FanartHandlerSetup.FhC.UpdateThumbnailTableOnStartup(new Utils.SubCategory[2]
          {
            Utils.SubCategory.MusicAlbumThumbScraped,
            Utils.SubCategory.MusicArtistThumbScraped
          }, 0);
          flag = true;
        }
        if (type.Equals("All") || type.Equals("UserManaged"))
        {
          FanartHandlerSetup.FhC.UpdateFanartUserManagedTable();
          flag = true;
        }
        if (type.Equals("All") || type.Equals("External"))
        {
          FanartHandlerSetup.FhC.UpdateFanartExternalTable();
          flag = true;
        }

        if (flag)
        {
          FanartHandlerSetup.FhC.StripStatusLabelToolTipText = "Done / Idle";
          FanartHandlerSetup.FhC.StripProgressBarValue = 0;
        }

      }
      catch (Exception ex)
      {
        logger.Error("OnRunWorkerCompleted: " + ex);
      }
    }
  }
}
