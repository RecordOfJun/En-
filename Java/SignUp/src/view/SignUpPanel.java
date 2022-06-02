package view;
import javax.swing.*;
import java.awt.*;
public class SignUpPanel extends JPanel {
	private Image backgroundImage=new ImageIcon("images/battleGround.jpg").getImage().getScaledInstance(1000, 600, Image.SCALE_DEFAULT);
	public JButton a=new JButton("뒤로가기");
	
	public SignUpPanel() {
		setSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));
		setPreferredSize(new Dimension(backgroundImage.getWidth(null), backgroundImage.getHeight(null)));	
		setLayout(null);
		this.add(a);
		a.setBounds(500, 500, 100, 50);
	}
	public void paintComponent(Graphics g) {
		g.drawImage(backgroundImage, 0,0,null);
		setOpaque(false);
	}
}

