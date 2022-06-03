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
		showMessageDialog(null, "아이디 비밀번호를 확인해 주세요!", "로그인 실패",JOptionPane.ERROR_MESSAGE);
	}
	
	public void alertIDCheck() {
		showMessageDialog(null, "아이디 중복을 확인해 주세요!", "회원가입 오류",JOptionPane.ERROR_MESSAGE);
	}
	
	public void alertNotCorrectPassword() {
		showMessageDialog(null, "비밀번호를 확인해 주세요!", "회원가입 오류",JOptionPane.ERROR_MESSAGE);
	}
	
	public void alertNotSamePassword() {
		showMessageDialog(null, "동일한 비밀번호를 입력해 주세요!", "회원가입 오류",JOptionPane.ERROR_MESSAGE);
	}
	
	public void alertPhone() {
		showMessageDialog(null, "전화번호를 확인해 주세요!", "회원가입 오류",JOptionPane.ERROR_MESSAGE);
	}
	
	public void alertAdress() {
		showMessageDialog(null, "주소를 확인해 주세요!", "회원가입 오류",JOptionPane.ERROR_MESSAGE);
	}
	
	public void alertPersonalCheck() {
		showMessageDialog(null, "주민번호 중복을 확인해 주세요!", "회원가입 오류",JOptionPane.ERROR_MESSAGE);
	}
	
	public void alertName() {
		showMessageDialog(null, "이름을 입력해 주세요!", "회원가입 오류",JOptionPane.ERROR_MESSAGE);
	}
	
	public void alertID() {
		showMessageDialog(null, "아이디 양식에 맞게 입력해주세요!", "중복확인 오류",JOptionPane.ERROR_MESSAGE);
	}
	
	public void alertIDOverlap() {
		showMessageDialog(null, "이미 가입된 아이디입니다!", "중복확인 오류",JOptionPane.ERROR_MESSAGE);
	}
	
	public void alertPersonal() {
		showMessageDialog(null, "주민번호 양식에 맞게 입력해 주세요!", "중복확인 오류",JOptionPane.ERROR_MESSAGE);
	}
	
	public void alertPersonalOverlap() {
		showMessageDialog(null, "이미 가입된 사용자입니다.!", "중복확인 오류",JOptionPane.ERROR_MESSAGE);
	}
}
