package controller;
import java.util.ArrayList;

import model.UserDAO;
import view.mainFrame;

public class Entrance {
	
	public boolean isExistedID(String idAndPw) {
		System.out.println(idAndPw);
		String id=idAndPw.split("/")[0];
		String pw=idAndPw.split("/")[1];
		String result=UserDAO.getInstance().CheckID(id, pw);
		System.out.println(result);
		if(result!=null&&result!="연결실패")
			return true;
		else return false;
	}
}
