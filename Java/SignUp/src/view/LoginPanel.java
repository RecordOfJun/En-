package view;
import javax.swing.*;
import java.awt.*;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
public class LoginPanel extends JPanel {
	private Image backgroundImage=new ImageIcon("images/space.jpg").getImage().getScaledInstance(1000, 630, Image.SCALE_DEFAULT);
	private JTextField idText=new JTextField();
	private JPasswordField pwText=new JPasswordField();
	private JLabel idLabel=new JLabel("ID");
	private JLabel pwLabel=new JLabel("PW");
	private JButton loginButton=new JButton("로그인");
	private JButton pwFindButton=new JButton("아이디/비밀번호 찾기");
	public JButton singUpButton=new JButton("회원가입");
	
	public LoginPanel() {
		setSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));
		setPreferredSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));	
		setLayout(null);
		setTextField();
		setLabel();
		setButton();
	}
	
	private void setTextField() {
		idText.setBounds(400, 300, 220, 50);
		idText.addKeyListener(new setTextLengthLimited());
		pwText.setBounds(400, 375, 220, 50);
		pwText.addKeyListener(new setTextLengthLimited());
		this.add(idText);
		this.add(pwText);
	}
	
	private void setLabel() {
		idLabel.setBounds(350, 300, 100, 50);
		pwLabel.setBounds(330, 375, 100, 50);
		idLabel.setForeground(Color.white);
		idLabel.setFont(new Font("맑은 고딕",Font.BOLD,30));
		pwLabel.setForeground(Color.white);
		pwLabel.setFont(new Font("맑은 고딕",Font.BOLD,30));
		this.add(idLabel);
		this.add(pwLabel);
	}
	
	private void setButton() {
		loginButton.setBounds(330, 440, 300, 50);
		pwFindButton.setBounds(330, 495, 300, 50);
		singUpButton.setBounds(330, 550, 300, 50);
		this.add(loginButton);
		this.add(pwFindButton);
		this.add(singUpButton);
	}
	
	public void paintComponent(Graphics g) {
		g.drawImage(backgroundImage, 0,0,null);
		setOpaque(false);
	}
	
	public class setTextLengthLimited extends KeyAdapter{
		public void keyTyped(KeyEvent e) {
			int maxLength=20;
			JTextField textField=(JTextField)e.getComponent();
			if(textField.getText().length()>maxLength) {
				e.consume();
				textField.setText(textField.getText().substring(0,maxLength-1));
			}
			else if(textField.getText().length()>=maxLength)
				e.consume();
		}
	}
}
