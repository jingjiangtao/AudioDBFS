# AudioDBFS
要求音频格式：pcm_s16le, ac=1, ar=16000

ffmpeg转换命令：ffmpeg -y -i test.m4a -acodec pcm_s16le -ac 1 -ar 16000 test.wav
