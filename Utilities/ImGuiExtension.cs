﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ExileCore;
using ExileCore.Shared.Nodes;
using ImGuiNET;

namespace AimBot.Utilities
{
    public class ImGuiExtension
    {
        //public static ImGuiVector4 CenterWindow(int width, int height)
        //{
        //    var centerPos = BasePlugin.API.GameController.Window.GetWindowRectangle().Center;
        //    return new ImGuiVector4(width + centerPos.X - width / 2, height + centerPos.Y - height / 2, width, height);
        //}

        //public static bool BeginWindow(string title, int x, int y, int width, int height, bool autoResize = false)
        //{
        //    ImGui.SetNextWindowPos(new ImGuiVector2(width + x, height + y), Condition.Appearing, new ImGuiVector2(1, 1));
        //    ImGui.SetNextWindowSize(new ImGuiVector2(width, height), Condition.Appearing);
        //    return ImGui.BeginWindow(title, autoResize ? WindowFlags.AlwaysAutoResize : WindowFlags.Default);
        //}
        //public static bool BeginWindowCenter(string title, int width, int height, bool autoResize = false)
        //{
        //    var size = CenterWindow(width, height);
        //    ImGui.SetNextWindowPos(new ImGuiVector2(size.X, size.Y), Condition.Appearing, new ImGuiVector2(1, 1));
        //    ImGui.SetNextWindowSize(new ImGuiVector2(size.Z, size.W), Condition.Appearing);
        //    return ImGui.BeginWindow(title, autoResize ? WindowFlags.AlwaysAutoResize : WindowFlags.Default);
        //}

        // Int Sliders
        public static int IntSlider(string labelString, int value, int minValue, int maxValue)
        {
            var refValue = value;
            ImGui.SliderInt(labelString, ref refValue, minValue, maxValue, "%.00f");
            return refValue;
        }

        public static int IntSlider(string labelString, string sliderString, int value, int minValue, int maxValue)
        {
            var refValue = value;
            ImGui.SliderInt(labelString, ref refValue, minValue, maxValue, sliderString);
            return refValue;
        }

        public static int IntSlider(string labelString, RangeNode<int> setting)
        {
            var refValue = setting.Value;
            ImGui.SliderInt(labelString, ref refValue, setting.Min, setting.Max, "%.00f");
            return refValue;
        }

        public static int IntSlider(string labelString, string sliderString, RangeNode<int> setting)
        {
            var refValue = setting.Value;
            ImGui.SliderInt(labelString, ref refValue, setting.Min, setting.Max, sliderString);
            return refValue;
        }

        public static int IntDrag(string labelString, RangeNode<int> setting)
        {
            var refValue = setting.Value;
            //ImGui.SliderInt(labelString, ref refValue, setting.Min, setting.Max, "%.00f");
            ImGui.DragInt(labelString, ref refValue, 0.1f, setting.Min, setting.Max, "%.00f");
            return refValue;
        }

        public static int IntDrag(string labelString, string sliderString, RangeNode<int> setting)
        {
            var refValue = setting.Value;
            //ImGui.SliderInt(labelString, ref refValue, setting.Min, setting.Max, "%.00f");
            ImGui.DragInt(labelString, ref refValue, 0.1f, setting.Min, setting.Max, sliderString);
            return refValue;
        }

        // float Sliders
        public static float FloatSlider(string labelString, float value, float minValue, float maxValue)
        {
            var refValue = value;
            ImGui.SliderFloat(labelString, ref refValue, minValue, maxValue, "%.00f", 1f);
            return refValue;
        }

        public static float FloatSlider(string labelString, float value, float minValue, float maxValue, float power)
        {
            var refValue = value;
            ImGui.SliderFloat(labelString, ref refValue, minValue, maxValue, "%.00f", power);
            return refValue;
        }

        public static float FloatSlider(string labelString, string sliderString, float value, float minValue, float maxValue)
        {
            var refValue = value;
            ImGui.SliderFloat(labelString, ref refValue, minValue, maxValue, sliderString, 1f);
            return refValue;
        }

        public static float FloatSlider(string labelString, string sliderString, float value, float minValue, float maxValue, float power)
        {
            var refValue = value;
            ImGui.SliderFloat(labelString, ref refValue, minValue, maxValue, sliderString, power);
            return refValue;
        }

        public static float FloatSlider(string labelString, RangeNode<float> setting)
        {
            var refValue = setting.Value;
            ImGui.SliderFloat(labelString, ref refValue, setting.Min, setting.Max, "%.00f", 1f);
            return refValue;
        }

        public static float FloatSlider(string labelString, RangeNode<float> setting, float power)
        {
            var refValue = setting.Value;
            ImGui.SliderFloat(labelString, ref refValue, setting.Min, setting.Max, "%.00f", power);
            return refValue;
        }

        public static float FloatSlider(string labelString, string sliderString, RangeNode<float> setting)
        {
            var refValue = setting.Value;
            ImGui.SliderFloat(labelString, ref refValue, setting.Min, setting.Max, sliderString, 1f);
            return refValue;
        }

        public static float FloatSlider(string labelString, string sliderString, RangeNode<float> setting, float power)
        {
            var refValue = setting.Value;
            ImGui.SliderFloat(labelString, ref refValue, setting.Min, setting.Max, sliderString, power);
            return refValue;
        }

        // Checkboxes
        public static bool Checkbox(string labelString, bool boolValue)
        {
            ImGui.Checkbox(labelString, ref boolValue);
            return boolValue;
        }

        public static bool Checkbox(string labelString, bool boolValue, out bool outBool)
        {
            ImGui.Checkbox(labelString, ref boolValue);
            outBool = boolValue;
            return boolValue;
        }

        // Hotkey Selector
        public static IEnumerable<Keys> KeyCodes() => Enum.GetValues(typeof(Keys)).Cast<Keys>();

        public static Keys HotkeySelector(string buttonName, Keys currentKey)
        {
            var open = true;
            if (ImGui.Button(buttonName))
            {
                ImGui.OpenPopup(buttonName);
                open = true;
            }

            if (ImGui.BeginPopupModal(buttonName, ref open, (ImGuiWindowFlags) 35))
            {
                if (Input.GetKeyState(Keys.Escape))
                {
                    ImGui.CloseCurrentPopup();
                    ImGui.EndPopup();
                }
                else
                {
                    foreach (var key in Enum.GetValues(typeof(Keys)))
                    {
                        var keyState = Input.GetKeyState((Keys) key);
                        if (keyState)
                        {
                            currentKey = (Keys) key;
                            ImGui.CloseCurrentPopup();
                            break;
                        }
                    }
                }

                ImGui.Text($" Press new key to change '{currentKey}' or Esc for exit.");

                ImGui.EndPopup();
            }

            return currentKey;
        }

        //// Color Pickers
        //public static Color ColorPicker(string labelName, Color inputColor)
        //{
        //    var color = inputColor.ToVector4();
        //    var colorToVect4 = new ImGuiVector4(color.X, color.Y, color.Z, color.W);
        //    if (ImGui.ColorEdit4(labelName, ref colorToVect4, ColorEditFlags.AlphaBar))
        //    {
        //        return new Color(colorToVect4.X, colorToVect4.Y, colorToVect4.Z, colorToVect4.W);
        //    }
        //    return inputColor;
        //}
    }
}