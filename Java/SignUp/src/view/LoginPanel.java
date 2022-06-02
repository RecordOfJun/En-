package view;
import javax.swing.*;
import java.awt.*;
public class LoginPanel extends JPanel {
	private Image backgroundImage=new ImageIcon("images/space.jpg").getImage().getScaledInstance(1000, 600, Image.SCALE_DEFAULT);
	private JTextField a=new JTextField("가나다라마바사");
	
	public LoginPanel() {
		this.add(a);
	}

	
	public void paintComponent(Graphics g) {
		g.drawImage(backgroundImage, 0,0,null);
		setOpaque(false);
	}
}
