using System;
using Bot.Builder.Community.Adapters.Google.Model;
using Newtonsoft.Json;

namespace Bot.Builder.Community.Adapters.Google
{
    public class SigninSystemIntent : ISystemIntent
    {
        public SigninSystemIntent()
        {
            Intent = "actions.intent.SIGN_IN";
        }

        public SigninSystemIntentData Data { get; set; }
    }

    public class SigninSystemIntentData : SystemIntentData
    {
        public SigninSystemIntentData()
        {
            Type = "type.googleapis.com/google.actions.v2.SignInValueSpec";
        }
    }
}
