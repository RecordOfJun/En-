package View;
import java.awt.Container;
import javax.swing.*;
public class Enlargement extends JFrame {
	ImageIcon image;
	public Enlargement(ImageIcon image) {
		this.image=image;
	}
	public void ShowForm() {
		setTitle("�̹��� Ȯ��");
		Container mainContainer=getContentPane();
		JLabel label=new JLabel(image);
		mainContainer.add(label);
		setSize(image.getIconWidth(), image.getIconHeight());
		setVisible(true);
	}
}