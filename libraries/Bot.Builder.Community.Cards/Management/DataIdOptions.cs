﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Bot.Builder.Community.Cards.Management
{
    public class DataIdOptions
    {
        private readonly IDictionary<string, string> _ids = new Dictionary<string, string>();

        public DataIdOptions(bool overwrite = false) => Overwrite = overwrite;

        public DataIdOptions(string type, bool overwrite = false)
            : this(overwrite) => _ids.Add(type, null);

        public DataIdOptions(IEnumerable<string> types, bool overwrite = false)
            : this(overwrite)
        {
            if (types is null)
            {
                throw new ArgumentNullException(nameof(types));
            }

            foreach (var type in types.Distinct())
            {
                _ids.Add(type, null);
            }
        }

        private DataIdOptions(IDictionary<string, string> ids, bool overwrite = false)
            : this(overwrite) => _ids = new Dictionary<string, string>(ids);

        public bool Overwrite { get; set; }

        public DataIdOptions Clone() => new DataIdOptions(_ids, Overwrite);

        public IEnumerable<string> GetIdTypes() => new HashSet<string>(_ids.Keys);

        public bool HasIdType(string type) => _ids.ContainsKey(type);

        public string Get(string type) => _ids.TryGetValue(type, out var value) ? value : null;

        public DataIdOptions Set(string type, string id = null)
        {
            _ids[type] = id;

            return this;
        }

        public IDictionary<string, string> GetIds() => new Dictionary<string, string>(_ids);
    }
}