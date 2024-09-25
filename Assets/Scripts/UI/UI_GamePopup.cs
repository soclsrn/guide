using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Define;

public class UI_GamePopup : UI_Popup
{
	enum Images
	{
		card1,
		card2,
		card3
	}
	enum Texts
	{
		//TestText
	}

	enum Buttons
	{
		StartButton,
		ContinueButton,
		CollectionButton
	}

	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		BindText(typeof(Texts));
		BindButton(typeof(Buttons));
		BindImage(typeof(Images));

		// GetButton((int)Buttons.StartButton).gameObject.BindEvent(OnClickStartButton);
		// GetButton((int)Buttons.ContinueButton).gameObject.BindEvent(OnClickContinueButton);
		// GetButton((int)Buttons.CollectionButton).gameObject.BindEvent(OnClickCollectionButton);


		//GetText((int)Texts.TestText).text = "game text";

		changeImageAlpha(0, 1);
        changeImageAlpha(0, 2);
        changeImageAlpha(0, 3);
        //StartCoroutine(srr(0.1f, 1));

        Managers.Sound.Clear();
		Managers.Sound.Play(Sound.Effect, "Sound_MainTitle");
		return true;
	}

    IEnumerator srr(float time , float img)
	{
		float uptime = 0f;
        while (uptime < time)
        {
            uptime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, uptime / time);
            changeImageAlpha(alpha, img);
            yield return null;
        }
        
    }

	void changeImageAlpha(float a , float img)
	{
		UnityEngine.Color alpha;
		switch (img)
		{
			case 1:
                alpha = GetImage((int)Images.card1).color;
                alpha.a = a;
                GetImage((int)Images.card1).color = alpha;
				break;
			case 2:
                alpha = GetImage((int)Images.card2).color;
                alpha.a = a;
                GetImage((int)Images.card2).color = alpha;
				break;
			case 3:
                alpha = GetImage((int)Images.card3).color;
                alpha.a = a;
                GetImage((int)Images.card3).color = alpha;
				break;

        } 
	}
	void OnClickStartButton()
	{
		Debug.Log("OnClickStartButton");
		Managers.Sound.Play(Sound.Effect, "Sound_FolderItemClick");

		// // 데이터 있는지 확인
		// if (Managers.Game.LoadGame())
		// {
		// 	Managers.UI.ShowPopupUI<UI_ConfirmPopup>().SetInfo(() =>
		// 	{
		// 		Managers.Game.Init();
		// 		Managers.Game.SaveGame();

		// 		Managers.UI.ClosePopupUI(this); // UI_TitlePopup
		// 		Managers.UI.ShowPopupUI<UI_NamePopup>();
		// 	}, Managers.GetText(Define.DataResetConfirm));
		// }
		// else
		// {
		// 	Managers.Game.Init();
		// 	Managers.Game.SaveGame();

		// 	Managers.UI.ClosePopupUI(this); // UI_TitlePopup
		// 	Managers.UI.ShowPopupUI<UI_NamePopup>();
		// }		
	}

	void OnClickContinueButton()
	{
		Debug.Log("OnClickContinueButton");
		Managers.Sound.Play(Sound.Effect, ("Sound_FolderItemClick"));
		// Managers.Game.Init();
		// Managers.Game.LoadGame();

		Managers.UI.ClosePopupUI(this);
		// Managers.UI.ShowPopupUI<UI_PlayPopup>();
	}

	void OnClickCollectionButton()
	{
		Managers.Sound.Play(Sound.Effect, ("Sound_FolderItemClick"));
		// Managers.Game.Init();
		// Managers.Game.LoadGame();

		Debug.Log("OnClickCollectionButton");
		// Managers.UI.ShowPopupUI<UI_CollectionPopup>();
	}
}
