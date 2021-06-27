using System.Collections.Generic;

namespace BlueberryEngine {

    /// <summary>
    /// Base interface for core systems
    /// </summary>
    public interface ISystem {

        public List<string> requirements { get; set; }

        public bool Matches(Entity entity) {
            foreach (string requirement in requirements)
                if (!entity.HasComponent(requirement))
                    return false;
            return true;
        }
    }
}
