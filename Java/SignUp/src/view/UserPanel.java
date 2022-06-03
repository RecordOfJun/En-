package view;
import javax.swing.*;
import java.awt.*;
public class UserPanel extends JPanel {
	private Image backgroundImage=new ImageIcon("images/space.jpg").getImage().getScaledInstance(1200, 720, Image.SCALE_DEFAULT);
	private JButton logOutButton=new JButton("로그아웃");
	private JButton withdrawalButton=new JButton("회원탈퇴");
	private JButton reviseButton=new JButton("정보수정");
	
	public UserPanel() {
		setSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));
		setPreferredSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));	
		setLayout(null);
	}
	
	private void setButton() {
		logOutButton.setBounds(ALLBITS, ABORT, WIDTH, HEIGHT);
	}
	
	public void paintComponent(Graphics g) {
		g.drawImage(backgroundImage, 0,0,null);
		setOpaque(false);
	}
}
