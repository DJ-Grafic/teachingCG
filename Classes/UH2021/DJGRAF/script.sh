#!/bin/bash

#go to root
cd ../../../

cd C#/Renderer 

dotnet run 

mv test.rbm ../../Classes/UH2021/DJGRAF/

cd ../../Classes/UH2021/DJGRAF

python3 imageviewer.py test.rbm

xdg-open dj_graphic.png