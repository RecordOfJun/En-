package view;
import java.awt.*;
import javax.swing.*;
public class menuPanel extends JPanel {
	private JLabel defaultLabel=new JLabel("표준");
	private JButton logButton=new JButton(new ImageIcon(new ImageIcon("image/log.png").getImage().getScaledInstance(40, 40, Image.SCALE_SMOOTH)));
	private JPanel leftPanel=new JPanel();
	private JPanel rightPanel=new JPanel();
	public menuPanel() {
		setPanel();
	}
	private void setPanel() {
		defaultLabel.setPreferredSize(new Dimension(400,40));
		defaultLabel.setFont(new Font("맑은 고딕",Font.BOLD,30));
		logButton.setPreferredSize(new Dimension(40,40));
		logButton.setBackground(this.getBackground());
		logButton.setBorder(getBorder());
		this.setLayout(new GridLayout(1,2));
		setLayOut();
		rightPanel.add(logButton);
		this.add(leftPanel);
		this.add(rightPanel);
	}
	private void setLayOut() {
		leftPanel.setLayout(new FlowLayout(FlowLayout.LEFT));
		leftPanel.setBackground(new Color(225,225,225));
		rightPanel.setLayout(new FlowLayout(FlowLayout.RIGHT));
		rightPanel.setBackground(new Color(225,225,225));
		leftPanel.add(defaultLabel);
	}
}
