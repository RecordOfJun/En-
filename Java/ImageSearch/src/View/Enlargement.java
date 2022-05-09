package View;
import java.awt.Container;
import java.awt.Image;
import javax.imageio.ImageIO;
import javax.swing.*;
public class Enlargement extends JFrame {
	ImageIcon image;
	public Enlargement(ImageIcon image) {
		this.image=image;
	}
	private void EnlargeImage() {
		image=new ImageIcon(image.getImage().getScaledInstance(500, 500, Image.SCALE_SMOOTH));
	}
	public void ShowForm() {
		setTitle("이미지 확대");
		EnlargeImage();
		Container mainContainer=getContentPane();
		JLabel label=new JLabel(image);
		mainContainer.add(label);
		setSize(500, 500);
		setVisible(true);
	}
}
