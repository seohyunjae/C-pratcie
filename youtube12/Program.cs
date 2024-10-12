using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

class Program
{
    static async Task Main(string[] args)
    {
        // YoutubeExplode 클라이언트 생성
        var youtube = new YoutubeClient();

        // 다운로드할 유튜브 영상 URL 또는 ID
        string videoUrl = "https://www.youtube.com/watch?v=YOUR_VIDEO_ID";

        // 비디오 정보 가져오기
        var video = await youtube.Videos.GetAsync(videoUrl);
        Console.WriteLine($"다운로드 중: {video.Title}");

        // 비디오 스트림 정보 가져오기
        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoUrl);

        // 가장 높은 품질의 비디오와 오디오 스트림 선택
        var streamInfo = streamManifest.GetMuxedStreams().OrderByDescending(s => s.VideoQuality).FirstOrDefault();

        if (streamInfo != null)
        {
            // 파일 경로 지정 - C:\AutoCoder 경로에 다운로드
            var filePath = Path.Combine(@"C:\AutoCoder", $"{video.Title}.mp4");

            // 경로가 없으면 생성
            Directory.CreateDirectory(@"C:\AutoCoder");

            // 스트림 다운로드
            await youtube.Videos.Streams.DownloadAsync(streamInfo, filePath);

            Console.WriteLine($"다운로드 완료: {filePath}");
        }
        else
        {
            Console.WriteLine("해당 비디오에 적합한 스트림을 찾을 수 없습니다.");
        }
    }
}
