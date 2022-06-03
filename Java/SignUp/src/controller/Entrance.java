package controller;
import java.util.ArrayList;

import model.UserDAO;
import view.Dialog;
import view.mainFrame;

public class Entrance {
	
	public boolean isExistedID(String idAndPw) {
		String id=idAndPw.split("/")[0];
		String pw=idAndPw.split("/")[1];
		String result=UserDAO.getInstance().CheckID(id, pw);
		System.out.println(result+".");
		if(result.equals(id))
			return true;
		else {
			Dialog.getInstance().loginFail();
			return false;
		}
	}
}
