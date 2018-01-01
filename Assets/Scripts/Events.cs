public class QuestAccepted : GameEvent {
	private int id;
	public int Id { get { return id; } }
	public QuestAccepted(int id) {
		this.id = id;
	}
}

public class QuestCompleted : GameEvent {
	private int id;
	public int Id { get { return id; } }
	public QuestCompleted(int id) {
		this.id = id;
	}
}

public class QuestFailed : GameEvent {
	private int id;
	public int Id { get { return id; } }
	public QuestFailed(int id) {
		this.id = id;
	}
}