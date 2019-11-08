using System.Linq;
using UnityEngine;

/// <summary>
/// Singleton base class; provides a static accessor to Components that are only ever in one instance.
/// If marked as DontDestroyOnLoad in the inspector, the root gameObject is not destroyed when loading new scenes.
/// </summary>
public abstract class SingletonObject<T> : MonoBehaviour where T : SingletonObject<T>
{
    /// <summary>
    /// Static singleton instance of the component.
    /// </summary>
    static T m_Instance = null;
    public static T Instance {
        get {
            if (!m_Instance)
            {
                m_Instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();
            }
            return m_Instance;
        }
    }
}