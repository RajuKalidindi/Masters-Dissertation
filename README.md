# Masters-Dissertation
## RingAuth - A secure and engaging user authentication

This authentication method is developed and tested on Unity(v2021.3.5f1 LTS) using C# programming language and Oculus Quest 1. The XR Interaction toolkit on unity ensures that the application is supported on various head mounted displays.

## Prerequisites:

1) Unity (v2021.3.5f1) with android build support module

2) Zip file of project folder

3) VR headset to test

4) Microsoft Visual Studio Community 2019

## Import and Build Project:

1) Initially download the zip file and extract it. Then in the unity hub, import the extracted project by selecting the file after clicking 'Add project from disk'.

2) The project takes a while to import. 

3) Before building the project make sure that XR Interaction Toolkit (v2.0.2) and XR Plugin Management (v4.2.1) packages are added to the project. All the installed packages can be found under "Window -> Package Manager" tab in unity.

4) Under the "Edit -> Project Settings -> XR Plug-in Management -> Android icon" tab, select Oculus checkbox if unchecked.

5) Connect the VR headset to the PC and make sure that the headset is in developer mode.

6) To run the project: Click on "File -> Build Settings". 

7) Make sure that the platform selected is Android

8) Select the required scene out of the three active options and click on "Build and Run" and then save the apk file

9) The apk should be built and directly run on the VR headset

10) To try other scenes, under build settings change the scene that is required

## Project Structure - Important folders:

1) *Prefab:* Consists of all the models of the rings and controllers that were tested

2) *Scenes:* Consists of the three user authentication methods and the test scenes

3) *Scripts:* Consists of the C# script that handles the interactions with the rings and the timer
   
