#!/usr/bin/env python

from python_speech_features import mfcc
from python_speech_features import delta
from python_speech_features import logfbank
import scipy.io.wavfile as wav
import sys


def cal_mfcc(fileAudio):
    # (rate, sig) = wav.read("english.wav")
    # mfcc_feat = mfcc(sig, rate)
    # print(mfcc_feat[0])
    (rate, sig) = wav.read(fileAudio)

    mfcc_feat = mfcc(sig, rate)
    print(len(mfcc_feat))
    print(mfcc_feat[0])

    myFile = open("mfcc.txt", "w")
    t = ""
    for i in range(len(mfcc_feat)):
        numFeat = len(mfcc_feat[i])
        for j in range(numFeat):
            t += str(mfcc_feat[i][j])
            if j < numFeat - 1:
                t += " "
        t += "\n"

    myFile.write(t)
    myFile.close()


if __name__ == "__main__":
    print(sys.argv)
    print(sys.argv[1])
    cal_mfcc(sys.argv[1])
