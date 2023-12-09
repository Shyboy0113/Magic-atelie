using System;
using UnityEngine;

/*
    �̱��� ������ ���� ���׸� Ŭ����
    ��� Ŭ������ Monobehaviour�� ��ӹ޵��� where �� ���

    ��� �� ������:
    Class Name �� GameObject Name�� ��ġ�ؾ� �Ѵ�.
*/

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static readonly object lockObject = new();

    private static T instance;

    public static T Instance
    {
        get
        {
            // Thread safe
            lock (lockObject)
            {
                // ���� ��ü�� ������� �ʾҴٸ�,
                if (!instance)
                {
                    // ������ ��ü�� ã�´�.
                    instance = (T)FindObjectOfType(typeof(T));

                    // ��ã�Ҵٸ� ��ü ������ �� �� ���̱� ������ Resources �������� Prefab�� �����´�.
                    if (!instance)
                    {
                        instance = Instantiate(Resources.Load<T>("Singleton/" + typeof(T).Name));
                    }
                    DontDestroyOnLoad(instance.gameObject);
                }
            }
            return instance;
        }
    }

    private void OnDestroy()
    {
        instance = null;
    }


}