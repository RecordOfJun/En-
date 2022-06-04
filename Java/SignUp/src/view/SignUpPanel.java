package view;
import javax.swing.*;
import javax.swing.text.AttributeSet.ColorAttribute;

import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import utility.ListenerManagement;
import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;
public class SignUpPanel extends JPanel {
	private Image backgroundImage=new ImageIcon("images/earth.jpg").getImage().getScaledInstance(1280, 720, Image.SCALE_DEFAULT);
	public JButton backButton=new JButton("뒤로가기");
	public JButton idCheckButton=new JButton("ID 중복 확인");
	public JButton personalCheckButton=new JButton("주민번호 확인");
	public JButton adressFindButton=new JButton("주소 찾기");
	public JButton completeButton=new JButton("가입 완료");
	public JButton reviseButton=new JButton("수정 완료");
	public JButton backToUserButton=new JButton("뒤로가기");
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
	public JTextField adressField=new JTextField();
	private JTextField detailAdressField=new JTextField();
	public boolean isCheckedID=false;
	public boolean isCheckedPersonal=false;
	
	public SignUpPanel() {
		setSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));
		setPreferredSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));	
		setLayout(null);
		setLabel();
		setButton();
		setTextField();
	}
	
	private void setButton() {
		idCheckButton.setBounds(800, 50, 150, 50);
		idCheckButton.setFocusable(false);
		personalCheckButton.setBounds(800, 350, 150, 50);
		personalCheckButton.setFocusable(false);
		adressFindButton.setBounds(800, 500, 150, 50);
		adressField.setFocusable(false);
		completeButton.setBounds(450, 650, 200, 50);
		completeButton.setFocusable(false);
		backButton.setBounds(650, 650, 200, 50);
		backButton.setFocusable(false);
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
		label.setBounds(220, y, 200, 50);
		label.setForeground(Color.white);
		label.setFont(new Font("맑은 고딕",Font.BOLD,30));
		label.setHorizontalAlignment(JLabel.RIGHT);
		this.add(label);
	}
	
	public void setTextField() {
		setTextBoundAndLimit(idField,0,50,300,15,"영문과 숫자를 혼합해 8~15자 이내로 입력해주세요.");
		idField.addKeyListener(new idRevised());
		pwField.setEchoChar((char)0);
		ListenerManagement.getInstance().linkPasswordFocusEvent("대문자,소문자,숫자,특수문자 포함 8~15자 이내로 입력해주세요.", pwField);
		setTextBoundAndLimit(pwField,0,125,300,15,"대문자,소문자,숫자,특수문자 포함 8~15자 이내로 입력해주세요.");
		pwConfirmField.setEchoChar((char)0);
		ListenerManagement.getInstance().linkPasswordFocusEvent("비밀번호를 동일하게 한번 더 입력해주세요.", pwConfirmField);
		setTextBoundAndLimit(pwConfirmField,0,200,300,15,"비밀번호를 동일하게 한번 더 입력해주세요.");
		setTextBoundAndLimit(nameField,0,275,200,10,"이름을 입력해주세요.");
		birthField.addKeyListener(new personalRevised());
		personalField.addKeyListener(new personalRevised());
		setTextBoundAndLimit(birthField,0,350,150,6,"생년월일을 입력해주세요");
		personalField.setEchoChar((char)0);
		ListenerManagement.getInstance().linkPasswordFocusEvent("뒤 7자리를 입력해주세요.", personalField);
		setTextBoundAndLimit(personalField,160,350,150,7,"뒤 7자리를 입력해주세요.");
		setTextBoundAndLimit(phoneNumberLeftField,0,425,100,3,"xxx");
		setTextBoundAndLimit(phoneNumberCenterField,110,425,100,4,"xxxx");
		setTextBoundAndLimit(phoneNumberRightField,220,425,100,4,"xxxx");
		adressField.setEditable(false);
		setTextBoundAndLimit(adressField,0,500,300,0,"");
		setTextBoundAndLimit(detailAdressField,0,575,400,50,"세부 주소를 입력해주세요.");
	}
	
	private void setTextBoundAndLimit(JTextField textField,int x,int y,int width,int maxLength,String text) {
		textField.setBounds(470+x, y, width, 50);
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
	
	public class idRevised extends KeyAdapter{
		public void keyTyped(KeyEvent e) {
			isCheckedID=false;
		}
	}
	
	public class personalRevised extends KeyAdapter{
		public void keyTyped(KeyEvent e) {
			isCheckedPersonal=false;
		}
	}
	
	public ArrayList<String> getInsertData() {
		ArrayList<String> insertData=new ArrayList<String>();
		insertData.add(defaultCheck(idField));
		insertData.add(String.valueOf(pwField.getPassword()));
		insertData.add(String.valueOf(pwConfirmField.getPassword()));
		insertData.add(defaultCheck(nameField));
		insertData.add(birthField.getText()+String.valueOf(personalField.getPassword()));
		insertData.add(phoneNumberLeftField.getText()+phoneNumberCenterField.getText()+phoneNumberRightField.getText());
		insertData.add(adressField.getText());
		insertData.add(defaultCheck(detailAdressField));
		return insertData;
	}
	
	private String defaultCheck(JTextField textField) {
		String text="";
		if(textField.getFont().getSize()==10)
			return text;
		else
			return textField.getText();
		
	}
	
	public void setReviesForm(ArrayList<String> userData) {
		setReviseButton();
		setReviseField(userData);
		isCheckedID=true;
		isCheckedPersonal=true;
	}
	
	private void setReviseButton() {
		idCheckButton.setVisible(false);
		personalCheckButton.setVisible(false);
		completeButton.setVisible(false);
		backButton.setVisible(false);
		reviseButton.setBounds(450, 650, 200, 50);
		reviseButton.setFocusable(false);
		backToUserButton.setBounds(650, 650, 200, 50);
		backToUserButton.setFocusable(false);
		this.add(reviseButton);
		this.add(backToUserButton);
	}
	
	private void setReviseField(ArrayList<String> userData) {
		String leftPhone=userData.get(4).substring(0,3);
		String CenterPhone;
		String rightPhone;
		if(userData.get(4).length()==10) {
			CenterPhone=userData.get(4).substring(3, 6);
			rightPhone=userData.get(4).substring(6);
		}
		else {
			CenterPhone=userData.get(4).substring(3,7);
			rightPhone=userData.get(4).substring(7);
		}
		idField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		idField.setEditable(false);
		idField.setBackground(Color.lightGray);
		pwField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		pwField.setEchoChar('*');
		pwConfirmField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		pwConfirmField.setEchoChar('*');
		idField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		nameField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		birthField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		birthField.setEditable(false);
		birthField.setBackground(Color.lightGray);
		personalField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		personalField.setEditable(false);
		personalField.setBackground(Color.lightGray);
		phoneNumberLeftField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		phoneNumberCenterField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		phoneNumberRightField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		adressField.setFont(new Font("맑은 고딕",Font.PLAIN,15));
		detailAdressField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
		idField.setText(userData.get(0));
		pwField.setText(userData.get(1));
		pwConfirmField.setText(userData.get(1));
		nameField.setText(userData.get(2));
		birthField.setText(userData.get(3).substring(0,6));
		personalField.setText(userData.get(3).substring(6));
		phoneNumberLeftField.setText(leftPhone);
		phoneNumberCenterField.setText(CenterPhone);
		phoneNumberRightField.setText(rightPhone);
		adressField.setText(userData.get(5));
		detailAdressField.setText(userData.get(6));
	}
}

