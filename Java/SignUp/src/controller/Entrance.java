package controller;
import java.util.ArrayList;

import model.UserDAO;
import view.Dialog;
import view.mainFrame;

public class Entrance {
	
	public boolean isExistedID(String idAndPw) {
		if(idAndPw.replace("/", "").equals("")) {
			Dialog.getInstance().loginFail();
			return false;
		}
		String id=idAndPw.split("/")[0];
		String pw=idAndPw.split("/")[1];
		System.out.println(idAndPw+".");
		String result=UserDAO.getInstance().CheckID(id, pw);
		if(result.equals(id))
			return true;
		else {
			Dialog.getInstance().loginFail();
			return false;
		}
	}
}
