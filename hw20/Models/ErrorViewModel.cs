using System;

namespace hw20.Models
{
    /// <summary>
    /// ��������� ������
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
