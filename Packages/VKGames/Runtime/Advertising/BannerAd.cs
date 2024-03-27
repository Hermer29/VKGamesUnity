using AOT;
using System;
using System.Runtime.InteropServices;

namespace Agava.VKGames
{
    public static class BannerAd
    {
        private static Action s_onErrorCallback;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bannerLocation">Can take values "top", "bottom"</param>
        /// <param name="onSuccess"></param>
        /// <param name="onError"></param>
        public static void Show(string bannerLocation = "bottom", Action onError = null)
        {
            s_onErrorCallback = onError;

            ShowBannerAd(bannerLocation, OnErrorCallback);
        }
        
        [DllImport("__Internal")]
        private static extern void ShowBannerAd(string bannerLocation, Action errorCallback);

        [MonoPInvokeCallback(typeof(Action))]
        private static void OnErrorCallback()
        {
            s_onErrorCallback?.Invoke();
        }
    }
}