package view;
import javax.swing.*;

import utility.ListenerManagement;
import java.awt.*;
public class SignUpPanel extends JPanel {
	private Image backgroundImage=new ImageIcon("images/battleGround.jpg").getImage().getScaledInstance(1000, 800, Image.SCALE_DEFAULT);
	public JButton backButton=new JButton("뒤로가기");
	private JButton idCheckButton=new JButton("ID 중복 확인");
	private JButton personalCheckButton=new JButton("주민번호 확인");
	private JButton adressFindButton=new JButton("주소 찾기");
	private JButton completeButton=new JButton("가입 완료");
	private JLabel idLabel=new JLabel("ID");
	private JLabel pwLabel=new JLabel("PW");
	private JLabel pwConfirmLabel=new JLabel("PW확인");
	private JLabel nameLabel=new JLabel("이름");
	private JLabel personalCodeLabel=new JLabel("주민번호");
	private JLabel phoneNumberLabel=new JLabel("전화번호");
	private JLabel adressLabel=new JLabel("주소");
	private JTextField idField=new JTextField();
	private JPasswordField pwField=new JPasswordField();
	private JPasswordField pwConfirmField=new JPasswordField();
	private JTextField nameField=new JTextField();
	private JTextField birthField=new JTextField();
	private JPasswordField personalField=new JPasswordField();
	private JTextField phoneNumberLeftField=new JTextField();
	private JTextField phoneNumberCenterField=new JTextField();
	private JTextField phoneNumberRightField=new JTextField();
	private JTextField adressField=new JTextField();
	private JTextField detailAdressField=new JTextField();
	
	public SignUpPanel() {
		setSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));
		setPreferredSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));	
		setLayout(null);
		setLabel();
		setButton();
		setTextField();
	}
	
	private void setButton() {
		idCheckButton.setBounds(700, 50, 150, 50);
		personalCheckButton.setBounds(700, 350, 150, 50);
		adressFindButton.setBounds(700, 500, 150, 50);
		completeButton.setBounds(300, 650, 200, 50);
		backButton.setBounds(550, 650, 200, 50);
		this.add(backButton);
		this.add(idCheckButton);
		this.add(completeButton);
		this.add(adressFindButton);
		this.add(personalCheckButton);
	}
	
	private void setLabel() {
		setLabelFont(50, idLabel);
		setLabelFont(125, pwLabel);
		setLabelFont(200, pwConfirmLabel);
		setLabelFont(275, nameLabel);
		setLabelFont(350, personalCodeLabel);
		setLabelFont(425, phoneNumberLabel);
		setLabelFont(500, adressLabel);
	}
	
	private void setLabelFont(int y,JLabel label) {
		label.setBounds(120, y, 200, 50);
		label.setForeground(Color.white);
		label.setFont(new Font("맑은 고딕",Font.BOLD,30));
		label.setHorizontalAlignment(JLabel.RIGHT);
		this.add(label);
	}
	
	public void setTextField() {
		setTextBoundAndLimit(idField,0,50,300,15,"영문과 숫자를 혼합해 15자 이내로 입력해주세요.");
		pwField.setEchoChar((char)0);
		ListenerManagement.getInstance().linkPasswordFocusEvent("영문과 숫자를 혼합해 15자 이내로 입력해주세요.", pwField);
		setTextBoundAndLimit(pwField,0,125,300,20,"영문과 숫자를 혼합해 15자 이내로 입력해주세요.");
		pwConfirmField.setEchoChar((char)0);
		ListenerManagement.getInstance().linkPasswordFocusEvent("비밀번호를 동일하게 한번 더 입력해주세요.", pwConfirmField);
		setTextBoundAndLimit(pwConfirmField,0,200,300,20,"비밀번호를 동일하게 한번 더 입력해주세요.");
		setTextBoundAndLimit(nameField,0,275,200,10,"이름을 입력해주세요.");
		setTextBoundAndLimit(birthField,0,350,150,6,"생년월일을 입력해주세요");
		personalField.setEchoChar((char)0);
		ListenerManagement.getInstance().linkPasswordFocusEvent("뒤 7자리를 입력해주세요.", personalField);
		setTextBoundAndLimit(personalField,160,350,150,7,"뒤 7자리를 입력해주세요.");
		setTextBoundAndLimit(phoneNumberLeftField,0,425,100,3,"xxx");
		setTextBoundAndLimit(phoneNumberCenterField,110,425,100,4,"xxxx");
		setTextBoundAndLimit(phoneNumberRightField,220,425,100,4,"xxxx");
		setTextBoundAndLimit(adressField,0,500,300,0,"");
		setTextBoundAndLimit(detailAdressField,0,575,400,0,"세부 주소를 입력해주세요.");
	}
	
	private void setTextBoundAndLimit(JTextField textField,int x,int y,int width,int maxLength,String text) {
		textField.setBounds(370+x, y, width, 50);
		textField.setFont(new Font("맑은 고딕",Font.PLAIN,10));
		textField.setText(text);
		ListenerManagement.getInstance().linkTextLengthLimited(maxLength, textField);
		ListenerManagement.getInstance().linkTextFocusEvent(text, textField);
		this.add(textField);
	}
	
	
	public void paintComponent(Graphics g) {
		g.drawImage(backgroundImage, 0,0,null);
		setOpaque(false);
	}
	
	
}

