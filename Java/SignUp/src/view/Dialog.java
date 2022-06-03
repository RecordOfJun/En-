package view;

import javax.swing.JOptionPane;

public class Dialog extends JOptionPane {
public static Dialog instance;
	
	private Dialog() {};
	
	public static synchronized Dialog getInstance() {
		if(instance==null)
			instance=new Dialog();
		return instance;
	}
	
	public void loginFail() {
		showMessageDialog(null, "아이디 비밀번호를 확인하세요!", "로그인 실패",JOptionPane.ERROR_MESSAGE);
	}
}
