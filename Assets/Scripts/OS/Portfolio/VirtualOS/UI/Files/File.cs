using OS.Portfolio.VirtualOS.Files;
using OS.Portfolio.VirtualOS.Signals;
using OS.Utilities.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace OS.Portfolio.VirtualOS.UI.Files
{
	public class File : Draggable, IHighlightable, IPoolable<FileConstructor, IMemoryPool>
	{
		public long Id { get; private set; }

		public RectTransform RectTransform => _rectTransform;

		[Inject] private readonly SignalBus _signalBus;
		
		[SerializeField] private Image _highlightImage;
		[SerializeField] private Image _iconImage;

		[SerializeField] private TMP_Text _nameText;

		private EFileType _fileType;
		private string _action;

		private IMemoryPool _pool;
		
		public bool IsHighlighted { get; protected set; }

		public void OnSpawned(FileConstructor fileConstructor, IMemoryPool pool)
		{
			Id = fileConstructor.FileData.Id;

			_fileType = fileConstructor.FileData.Type;
			_action = fileConstructor.FileData.Action;
			_pool = pool;

			_iconImage.sprite = fileConstructor.Icon;

			_nameText.text = fileConstructor.FileData.Name;
		}

		public void Despawn()
		{
			_pool?.Despawn(this);
		}
		
		public void OnDespawned()
		{
			Id = -1;
			_action = null;
			_pool = null;
		}
	
		public void Highlight()
		{
			_highlightImage.enabled = true;
			
			IsHighlighted = true;
		}

		public void StopHighlighting()
		{
			_highlightImage.enabled = false;
			
			IsHighlighted = false;
		}

		public override void SingleClick(PointerEventData eventData)
		{
			base.SingleClick(eventData);

			_signalBus.Fire(new HighlightFileSignal(this));
		}

		public override void DoubleClick(PointerEventData eventData)
		{
			base.DoubleClick(eventData);

			_signalBus.Fire(new TriggerFileActionSignal(_fileType, _action));
		}

		public override void RightClick(PointerEventData eventData)
		{
			
		}

		public override void MiddleClick(PointerEventData eventData)
		{
			
		}
		
		public class Factory : PlaceholderFactory<FileConstructor, File> { }
	}
}
