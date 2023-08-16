from moviepy.editor import VideoFileClip

video = VideoFileClip("Media1.mp4")
audio = video.audio
audio.write_audiofile("audio_only.wav")
