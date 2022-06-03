package view;
import javax.swing.*;
import java.awt.*;
import java.awt.event.FocusAdapter;
import java.awt.event.FocusEvent;
import java.awt.event.FocusListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
public class SignUpPanel extends JPanel {
	private Image backgroundImage=new ImageIcon("images/battleGround.jpg").getImage().getScaledInstance(1000, 800, Image.SCALE_DEFAULT);
	public JButton backButton=new JButton("뒤로가기");
	private JButton idCheckButton=new JButton("ID확인");
	private JButton adressFindButton=new JButton("주소 찾기");
	private JLabel idLabel=new JLabel("ID");
	private JLabel pwLabel=new JLabel("PW");
	private JLabel pwConfirmLabel=new JLabel("PW확인");
	private JLabel nameLabel=new JLabel("이름");
	private JLabel personalCodeLabel=new JLabel("주민번호");
	private JLabel phoneNumberLabel=new JLabel("전화번호");
	private JLabel adressLabel=new JLabel("주소");
	private JTextField idField=new JTextField("영문과 숫자를 혼합해 15자 이내로 입력해주세요.");
	private JPasswordField pwField=new JPasswordField("영문과 숫자를 혼합해 15자 이내로 입력해주세요.");
	private JPasswordField pwConfirmField=new JPasswordField("비밀번호를 동일하게 한번 더 입력해주세요.");
	private JTextField nameField=new JTextField("이름을 입력해주세요.");
	private JTextField birthField=new JTextField("생년월일을 입력해주세요");
	private JTextField personalField=new JTextField("주민등록번호 뒤 7자리를 입력해주세요.");
	private JTextField phoneNumberLeftField=new JTextField("xxx");
	private JTextField phoneNumberCenterField=new JTextField("xxxx");
	private JTextField phoneNumberRightField=new JTextField("xxxx");
	private JTextField adressField=new JTextField("");
	private JTextField detailAdressField=new JTextField("세부 주소를 입력해주세요.");
	
	public SignUpPanel() {
		setSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));
		setPreferredSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));	
		setLayout(null);
		setLabel();
		setButton();
		setTextField();
	}
	
	private void setButton() {
		backButton.setBounds(500, 700, 100, 50);
		this.add(backButton);
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
	
	private void setTextField() {
		setTextBoundAndLimit(idField,0,50,300,15,"영문과 숫자를 혼합해 15자 이내로 입력해주세요.");
		setTextBoundAndLimit(pwField,0,125,300,20,"영문과 숫자를 혼합해 15자 이내로 입력해주세요.");
		pwField.addFocusListener(new passwordFocusEvent("영문과 숫자를 혼합해 15자 이내로 입력해주세요.", pwField));
		setTextBoundAndLimit(pwConfirmField,0,200,300,20,"비밀번호를 동일하게 한번 더 입력해주세요.");
		pwConfirmField.addFocusListener(new passwordFocusEvent("비밀번호를 동일하게 한번 더 입력해주세요.", pwConfirmField));
		setTextBoundAndLimit(nameField,0,275,200,10,"이름을 입력해주세요.");
		setTextBoundAndLimit(birthField,0,350,150,6,"생년월일을 입력해주세요");
		setTextBoundAndLimit(personalField,160,350,150,7,"주민등록번호 뒤 7자리를 입력해주세요.");
		setTextBoundAndLimit(phoneNumberLeftField,0,425,100,3,"xxx");
		setTextBoundAndLimit(phoneNumberCenterField,110,425,100,4,"xxxx");
		setTextBoundAndLimit(phoneNumberRightField,220,425,100,4,"xxxx");
		setTextBoundAndLimit(adressField,0,500,300,0,"");
		setTextBoundAndLimit(detailAdressField,0,575,400,0,"세부 주소를 입력해주세요.");
	}
	
	private void setTextBoundAndLimit(JTextField textField,int x,int y,int width,int maxLength,String text) {
		textField.setBounds(370+x, y, width, 50);
		textField.setFont(new Font("맑은 고딕",Font.PLAIN,10));
		textField.addKeyListener(new setTextLengthLimited(maxLength));
		textField.addFocusListener(new textFocusEvent(text, textField));
		this.add(textField);
	}
	
	
	public void paintComponent(Graphics g) {
		g.drawImage(backgroundImage, 0,0,null);
		setOpaque(false);
	}
	public class setTextLengthLimited extends KeyAdapter{
		int maxLength;
		public setTextLengthLimited(int maxLength) {
			this.maxLength=maxLength;
		}
		public void keyTyped(KeyEvent e) {
			JTextField textField=(JTextField)e.getComponent();
			if(textField.getText().length()>maxLength) {
				e.consume();
				textField.setText(textField.getText().substring(0,maxLength-1));
			}
			else if(textField.getText().length()>=maxLength)
				e.consume();
		}
	}
	
	public class textFocusEvent implements FocusListener{
		String defaultText;
		JTextField textField;
		public textFocusEvent(String defaultText,JTextField textField) {
			this.defaultText=defaultText;
			this.textField=textField;
		}
		public void focusGained(FocusEvent e) {
			if(textField.getText().equals(defaultText)) {
				textField.setText("");
				textField.setFont(new Font("맑은 고딕",Font.PLAIN,20));
			}
		}

		public void focusLost(FocusEvent e) {
			if(textField.getText().length()==0) {
				textField.setFont(new Font("맑은 고딕",Font.PLAIN,10));
				textField.setText(defaultText);
			}
		}
		
	}
	public class passwordFocusEvent implements FocusListener{
		String defaultText;
		JPasswordField textField;
		public passwordFocusEvent(String defaultText,JPasswordField textField) {
			this.defaultText=defaultText;
			this.textField=textField;
		}
		public void focusGained(FocusEvent e) {
			if(textField.getPassword().toString().equals(defaultText)) {
				textField.setEchoChar('*');
			}
		}

		public void focusLost(FocusEvent e) {
			if(textField.getPassword().toString().length()==0) {
				textField.setEchoChar((char)0);
			}
		}
		
	}
	
}

