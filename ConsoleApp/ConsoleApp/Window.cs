﻿using System;

namespace ProceduralLevel.ConsoleApp
{
	public class Window
	{
		private Canvas m_Canvas;
		private int m_Width;
		private int m_Height;
		private bool m_IsFullscreen;

		private Pixel[] m_Buffer;

		public int Width { get { return m_Width; } }
		public int Height { get { return m_Height; } }
		public bool IsFullscreen { get { return m_IsFullscreen; } }


		public Canvas Canvas { get { return m_Canvas; } }

		public Window(string title, bool fullscreen = false)
		{
			Init(title);
			SetFullscreen(fullscreen);
			SetMaxSize();
		}

		public Window(string title, int width, int height, bool fullscreen = false)
		{
			Init(title);
			SetFullscreen(fullscreen);
			SetSize(width, height);
		}

		private void Init(string title)
		{
			//disable mouse and line wrapping, to make sure everything displays as it should
			ConsoleHelper.SetInputMode(EInputMode.Default);
			ConsoleHelper.SetOutputMode(EOutputMode.Default);
			Console.CursorVisible = false;
			Console.Title = title;
		}

		public void Render()
		{
			ScreenBufferInfo bufferInfo = ConsoleHelper.GetScreenBufferInfo();
			if(bufferInfo.Size.X != m_Width || bufferInfo.Size.Y != m_Height)
			{
				SetSize(m_Width, m_Height);
			}
			m_Canvas.Render(this, 0, 0);

			ConsoleHelper.WriteOutput(m_Buffer, new Coord(Width, Height), new Coord(0, 0));
		}

		public void Plot(Pixel pixel, int x, int y)
		{
			m_Buffer[y*m_Width+x] = pixel;
		}

		public void SetFullscreen(bool fullscreen)
		{
			m_IsFullscreen = fullscreen;
			ConsoleHelper.SetFullScreen(fullscreen);
		}

		public void SetSize(int width, int height)
		{
			if(ConsoleHelper.SetSize(ref width, ref height))
			{
				m_Buffer = new Pixel[width*height];
				m_Width = width;
				m_Height = height;
				m_Canvas = new Canvas(width, height);
			}
		}

		public void SetMaxSize()
		{
			ScreenBufferInfo info = ConsoleHelper.GetScreenBufferInfo();
			SetSize(info.MaximumWindowSize.X, info.MaximumWindowSize.Y);
		}
	}
}
