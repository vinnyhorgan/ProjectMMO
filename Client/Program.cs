﻿using Raylib_cs;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int screenWidth = 800;
            const int screenHeight = 600;

            Raylib.SetTraceLogLevel(TraceLogLevel.LOG_NONE);
            Raylib.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);
            Raylib.InitWindow(screenWidth, screenHeight, "Project MMO");
            Raylib.SetTargetFPS(60);

            Raylib.InitAudioDevice();

            NetworkManager.Load();

            ImguiController imgui = new ImguiController();
            imgui.Load(screenWidth, screenHeight);

            ScreenManager.Switch(new MainScreen());

            while (!Raylib.WindowShouldClose())
            {
                float dt = Raylib.GetFrameTime();

                NetworkManager.Update(dt);

                imgui.Update(dt);

                ScreenManager.Update(dt);

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.SKYBLUE);

                ScreenManager.Draw();

                imgui.Draw();

                Raylib.EndDrawing();
            }

            NetworkManager.Unload();

            imgui.Dispose();

            ScreenManager.Unload();

            Raylib.CloseAudioDevice();
            Raylib.CloseWindow();
        }
    }
}
