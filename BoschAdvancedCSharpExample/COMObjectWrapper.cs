using System;

namespace AdvancedCSharpSample
{
	/// <summary>
	/// 
	/// </summary>
	public class PlaybackControllerWrapper
	{
		public Bosch.VideoSDK.MediaDatabase.PlaybackController m_pc = null;
	
		public PlaybackControllerWrapper(Bosch.VideoSDK.MediaDatabase.PlaybackController pc)
		{
			m_pc = pc;
		}

		~PlaybackControllerWrapper()
		{
			m_pc = null;
		}

		public override string ToString()
		{
			return m_pc.Name;
		}

	}

	public class TrackWrapper
	{
		public Bosch.VideoSDK.MediaDatabase.Track m_track = null;
	
		public TrackWrapper(Bosch.VideoSDK.MediaDatabase.Track track)
		{
			m_track = track;
		}

		public override string ToString()
		{
			return m_track.Name;
		}

	}
}
