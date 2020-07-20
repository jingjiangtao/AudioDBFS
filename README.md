# AudioDBFS
要求音频格式：pcm_s16le, 声道=1, 采样率=16000

ffmpeg转换命令：ffmpeg -y -i test.m4a -acodec pcm_s16le -ac 1 -ar 16000 test.wav
***
Required audio format: pcm_s16le, channel=1, sampling rate=16000

ffmpeg conversion command: ffmpeg -y -i test.m4a -acodec pcm_s16le -ac 1 -ar 16000 test.wav
